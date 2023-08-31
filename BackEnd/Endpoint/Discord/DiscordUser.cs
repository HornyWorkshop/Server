using System.Text.Json.Serialization;

namespace Endpoint.Discord;

public sealed record DiscordUser
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("username")]
    public string UserName { get; init; } = string.Empty;

    [JsonPropertyName("discriminator")]
    public short Discriminator { get; init; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    [JsonPropertyName("bot")]
    public bool? IsBot { get; init; }

    [JsonPropertyName("system")]
    public bool? IsSystem { get; init; }

    [JsonPropertyName("mfa_enabled")]
    public bool? IsMFfaEnabled;

    [JsonPropertyName("locale")]
    public string? Locale;

    [JsonPropertyName("verified")]
    public bool? IsVerified;

    [JsonPropertyName("email")]
    public string? Email;

    [JsonPropertyName("flags")]
    public int? Flags;

    [JsonPropertyName("premium_type")]
    public PremiumType? PremiumType;

    [JsonPropertyName("public_flags")]
    public int? PublicFlags;
};
