namespace HornyWorkshop.Services.WorkshopService.Extensions;

internal static class IConfigurationExtension
{
    internal static ulong? GetTextChannel(this IConfiguration @this, string name) => @this.GetValue<ulong?>($"TextChannels:{name}", null);
}
