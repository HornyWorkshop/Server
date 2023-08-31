using Endpoint.Commons;
using System.Collections.Generic;

namespace Endpoint.GraphQL.Inputs;

public sealed record CreateFranchiseInput
{
    public LocaleValue Name { get; init; } = default!;
    public IReadOnlyCollection<int> Tags { get; init; } = default!;
}
