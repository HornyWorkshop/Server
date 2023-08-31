using Microsoft.Extensions.DependencyInjection;
using System.Threading.Channels;

namespace HandWorkService.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddInstallerChannel(this IServiceCollection services) => services
        .AddSingleton(services => Channel.CreateUnbounded<TaskBase>());
}
