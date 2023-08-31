namespace Endpoint.Commons;

public sealed record LocaleValue : ILocaleValue
{
    public string Ru { get; init; } = default!;
    public string En { get; init; } = default!;
    public string Kr { get; init; } = default!;
    public string Jp { get; init; } = default!;
}
