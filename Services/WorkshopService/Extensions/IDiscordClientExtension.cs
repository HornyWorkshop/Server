using Discord;

namespace HornyWorkshop.Services.WorkshopService.Extensions;

internal static class IDiscordClientExtension
{
    internal static async ValueTask<ITextChannel> GetTextChannelAsync(this IDiscordClient @this, ulong id) => await @this.GetChannelAsync(id) is ITextChannel c ? c : throw new ApplicationException($"Bad channel: {id}");
}
