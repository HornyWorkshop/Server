using Endpoint.Application.Commands.Card;
using Endpoint.Database;
using Endpoint.Discord;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Endpoint.Application.Handlers.Card;

public sealed class UploadHandler : IRequestHandler<UploadCardCommand>
{
    public async Task<Unit> Handle(UploadCardCommand request, CancellationToken cancellationToken)
    {
        if (IsInvalidContentType(request.File.ContentType))
            throw new HttpRequestException(null, null, HttpStatusCode.BadRequest);

        if (IsInvalidExtension(request.File.FileName))
            throw new HttpRequestException(null, null, HttpStatusCode.BadRequest);

        await _queue.SendAsync(new DiscordUpload
        {
            CardId = request.Id,
            File = request.File,
        });

        return Unit.Value;
    }

    public UploadHandler(BufferBlock<DiscordUpload> queue, IDbContextFactory<DatabaseContext> factory) =>
        (_queue, _factory) = (queue, factory);

    private static bool IsInvalidExtension(string name) => !name.EndsWith(".png");

    private static bool IsInvalidContentType(string contentType) => contentType.Equals("image/png");

    private readonly BufferBlock<DiscordUpload> _queue;
    private readonly IDbContextFactory<DatabaseContext> _factory;
}
