
using Endpoint.Commons;
using Endpoint.Database.Models.Card;
using MediatR;
using System.Collections.Generic;

namespace Endpoint.Application.Commands.Card;

public sealed class AddCardCommand : IRequest<CardModel>
{
    public LocaleValue Name { get; init; } = default!;
    public ISet<int> Tags { get; init; } = default!;
    public ISet<int> Franchises { get; init; } = default!;
}