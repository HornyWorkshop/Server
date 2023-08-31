using Telegram.Bot;
using Telegram.Bot.Types;

namespace HornyWorkshop.Services.WorkshopService.BackgroundServices.TelegramServices;

public sealed class TelegramBackupServices : BackgroundService
{
    private readonly ItemReader _reader;
    private readonly ITelegramBotClient _client;

    private readonly int _chat;

    public TelegramBackupServices(ItemReader reader, ITelegramBotClient client, IConfiguration configuration)
    {
        _reader = reader;
        _client = client;

        _chat = configuration.GetValue<int>("ConnectionStrings:TelegramChat");
    }

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        await foreach (var item in _reader.ReadAllAsync(ct))
        {
            await using var stream = item.File.OpenReadStream();

            await _client.SendDocumentAsync(_chat, InputFile.FromStream(stream, item.File.Name), cancellationToken: ct);
        }
    }
}
