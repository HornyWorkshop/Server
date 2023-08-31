using Discord.WebSocket;
using Endpoint.Database;
using Endpoint.Database.Models.Chunk;
using Endpoint.Database.Models.File;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Endpoint.Discord;

public sealed class DiscordService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await foreach (var item in _queue.ReceiveAllAsync(cancellationToken))
        {
            await using var context = await _factory.CreateDbContextAsync(cancellationToken);
            
            var file = await CreateFile(context, item, cancellationToken);
            if (file is null) continue;

            await context.Files.AddAsync(file, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
        }
    }

    private async ValueTask<FileModel?> CreateFile(DatabaseContext context, DiscordUpload item, CancellationToken cancellationToken)
    {
        var card = await context.Cards.FirstOrDefaultAsync(c => c.Id == item.CardId, cancellationToken);
        if (card is null) return null;

        using var hash = MD5.Create();
        var checksumFile = await hash.ComputeHashAsync(item.File.OpenReadStream(), cancellationToken);

        if (await context.Files.AnyAsync(p => p.Checksum == checksumFile, cancellationToken)) 
            return null;

        await using var stream = item.File.OpenReadStream();

        List<ChunkModel> chunks = new();
        while (!cancellationToken.IsCancellationRequested && stream.Position != stream.Length)
        {
            var chunk = await CreateChunk(stream, context, item.File, cancellationToken);
            if (chunk is null) return null;

            chunks.Add(chunk);
        }

        return new FileModel
        {
            Name = item.File.Name,
            Checksum = checksumFile,
            Chunks = chunks
        };
    }

    private async ValueTask<ChunkModel?> CreateChunk(Stream stream, DatabaseContext context, IFormFile file, CancellationToken cancellationToken)
    {
        var buffer = new byte[MaxFileSize];
        await stream.ReadAsync(buffer, cancellationToken);

        using var hash = MD5.Create();
        var checksumChunk = hash.ComputeHash(buffer);

        var cached = await context.Chunks.FirstOrDefaultAsync(p => p.Checksum == checksumChunk, cancellationToken);
        if (cached is not null) return cached;

        var message = await _channel.SendFileAsync(stream, $"{file.FileName}_{stream.Position}", string.Empty);
        if (message is null) return null;

        var attachment = message.Attachments.FirstOrDefault();
        if (attachment is null) return null;

        return new ChunkModel
        {
            Checksum = checksumChunk,
            Url = attachment.Url,
        };
    }

    public override Task StopAsync(CancellationToken cancellationToken) => _discord.StopAsync();

    public override void Dispose() => _discord.Dispose();

    public DiscordService(IConfiguration configuration, IDbContextFactory<DatabaseContext> factory, BufferBlock<DiscordUpload> queue, DiscordSocketClient discord)
    {
        _factory = factory;
        _queue = queue;
        _discord = discord;

        if (discord.GetChannel(configuration.GetValue<ulong>("Discord:FileStashChannelId")) is not SocketTextChannel channel)
            throw new ApplicationException();

        _channel = channel;
    }

    private readonly IDbContextFactory<DatabaseContext> _factory;
    private readonly BufferBlock<DiscordUpload> _queue;
    private readonly DiscordSocketClient _discord;
    private readonly SocketTextChannel _channel;

    private const int MaxFileSize = 8_000_000;
}
