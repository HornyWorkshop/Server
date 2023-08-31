using Telegram.Bot;

namespace HornyWorkshop.Services.WorkshopService.BackgroundServices.TelegramServices;

public sealed class TelegramLifetimeService : BackgroundService
{
    private readonly ITelegramBotClient _client;
    private readonly IConfiguration _configuration;

    public TelegramLifetimeService(ITelegramBotClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        await _client.GetMeAsync(ct);
    }
}
