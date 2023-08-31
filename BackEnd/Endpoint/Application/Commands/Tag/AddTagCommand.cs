using Endpoint.Commons;
using Endpoint.Database.Models.Tag;
using MediatR;

namespace Endpoint.Application.Commands.Tag;

public sealed record AddTagCommand : IRequest<TagModel>
{
    public LocaleValue Name { get; init; } = default!;
}