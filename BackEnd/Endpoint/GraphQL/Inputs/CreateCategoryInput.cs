using Endpoint.Commons;

namespace Endpoint.GraphQL.Inputs;

public sealed record CreateTagInput
{
    public LocaleValue Name { get; init; } = default!;
}
