using Microsoft.AspNetCore.Http;

namespace Endpoint.Discord;

public sealed record DiscordUpload
{
    public int CardId { get; init; }
    public IFormFile File { get; init; } = default!;
}
