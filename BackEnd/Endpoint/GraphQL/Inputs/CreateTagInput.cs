using Endpoint.Commons;

namespace Endpoint.GraphQL.Inputs;

public sealed record CreateCategoryInput
{
    public LocaleValue Name { get; init; } = default!;
}
