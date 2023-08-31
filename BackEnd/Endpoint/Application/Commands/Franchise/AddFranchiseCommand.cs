using Endpoint.Commons;
using Endpoint.Database.Models.Franchise;
using MediatR;
using System.Collections.Generic;

namespace Endpoint.Application.Commands.Franchise;

public sealed record AddFranchiseCommand : IRequest<FranchiseModel>
{
    public LocaleValue Name { get; set; } = default!;
    public ISet<int> Tags { get; set; } = default!;
}