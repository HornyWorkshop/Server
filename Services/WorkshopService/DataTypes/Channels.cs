using Discord;
using HornyWorkshop.Services.WorkshopService.Extensions;

namespace HornyWorkshop.Services.WorkshopService.DataTypes;

public sealed record Channels
{
    internal ITextChannel Stash { get; private set; } = default!;

    internal async ValueTask FetchAsync(IDiscordClient discord, IConfiguration configuration)
    {
        var stashId = configuration.GetTextChannel("Stash");
        ArgumentNullException.ThrowIfNull(stashId);

        Stash = await discord.GetTextChannelAsync(stashId.Value);
    }
}
