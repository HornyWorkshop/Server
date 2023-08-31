using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Endpoint;

public static class Program
{
    public static Task Main(string[] args) => CreateHostBuilder(args).Build().RunAsync();

    public static IHostBuilder CreateHostBuilder(string[] args) => Host
        .CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(configure => configure.UseStartup<Startup>());
    // .ConfigureServices(configure => configure.AddHostedService<DiscordService>());
}
