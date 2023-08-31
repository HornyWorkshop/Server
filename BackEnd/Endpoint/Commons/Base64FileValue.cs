namespace Endpoint.Commons;

public sealed record Base64FileValue
{
    public string Value { get; init; } = default!;
    public string Name { get; init; } = default!;
}
