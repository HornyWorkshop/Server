using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Endpoint.Discord;

public sealed class DiscordSocketClientFactory
{
    public async Task<DiscordSocketClient> Create()
    {
        var token = _configuration.GetValue("Discord:Token", string.Empty);

        var client = new DiscordSocketClient(new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Verbose,
            DefaultRetryMode = RetryMode.AlwaysFail
        });

        client.Log += LogAsync;

        var tcs = new TaskCompletionSource();

        client.Ready += () =>
        {
            tcs.SetResult();
            return Task.CompletedTask;
        };

        await client.LoginAsync(TokenType.Bot, token);
        await client.StartAsync();
        await tcs.Task;

        return client;
    }

    public DiscordSocketClientFactory(IConfiguration configuration, ILogger<DiscordSocketClient> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    private Task LogAsync(LogMessage message)
    {
        switch (message.Severity)
        {
            case LogSeverity.Critical:
                _logger.LogCritical(message.Exception, message.Message);
                break;

            case LogSeverity.Warning:
                _logger.LogWarning(message.Exception, message.Message);
                break;

            case LogSeverity.Info:
                _logger.LogInformation(message.Exception, message.Message);
                break;

            case LogSeverity.Verbose:
                _logger.LogInformation(message.Exception, message.Message);
                break;

            case LogSeverity.Debug:
                _logger.LogDebug(message.Exception, message.Message);
                break;

            case LogSeverity.Error:
                _logger.LogError(message.Exception, message.Message);
                break;
        }

        return Task.CompletedTask;
    }

    private readonly IConfiguration _configuration;
    private readonly ILogger<DiscordSocketClient> _logger;
}
