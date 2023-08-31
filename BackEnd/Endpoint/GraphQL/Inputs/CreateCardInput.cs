using Endpoint.Commons;
using System.Collections.Generic;

namespace Endpoint.GraphQL.Inputs;

public sealed class CreateCardInput
{
    public LocaleValue Name { get; init; } = default!;
    public IReadOnlyCollection<int> Tags { get; init; } = default!;
    public IReadOnlyCollection<int> Franchises { get; init; } = default!;
}
