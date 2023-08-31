using Discord.WebSocket;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiscordUploader
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            var path = args.ElementAtOrDefault(0);
            if (path is null) return;

            var discord = await DiscordCustomClient.Create();
            if (discord.GetChannel(839938598241697812) is not SocketTextChannel channel) return;

            var filename = Path.GetFileName(path);
            if (filename is null) return;

            var sources = await new Sources(path).SelectAwait(async (stream, index) =>
            {
                Console.WriteLine("Id: {0}", 1 + index);

                var message = await channel.SendFileAsync(stream, $"{filename}_{index}", "");
                return message.Attachments.First().Url;
            }).ToArrayAsync();

            var tempFilePath = Path.GetTempFileName();

            var serealized = JsonSerializer.Serialize(sources);
            await File.WriteAllTextAsync(tempFilePath, serealized);

            Process.Start("notepad.exe", tempFilePath);
        }
    }
}
