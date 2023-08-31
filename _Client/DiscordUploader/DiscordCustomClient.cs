using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordUploader
{
    public class DiscordCustomClient : DiscordSocketClient
    {
        public Task WaitReady()
        {
            var tsc = new TaskCompletionSource();

            Ready += () =>
            {
                tsc.SetResult();
                return Task.CompletedTask;
            };

            return tsc.Task;
        }

        public static async ValueTask<DiscordCustomClient> Create()
        {
            var discord = new DiscordCustomClient();

            await discord.LoginAsync(TokenType.Bot, "ODM5OTQ2ODMzNDU5MDE5ODE2.YJRDcg.TAzBqmBuxqbmuSG3CHalHWkVTxA");
            await discord.StartAsync();
            await discord.WaitReady();

            return discord;
        }
    }
}
