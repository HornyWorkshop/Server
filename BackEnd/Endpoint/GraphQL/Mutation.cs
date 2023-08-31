using AutoMapper;
using Endpoint.Application.Commands.Card;
using Endpoint.Application.Commands.Category;
using Endpoint.Application.Commands.Franchise;
using Endpoint.Application.Commands.Tag;
using Endpoint.Database.Models.Card;
using Endpoint.Database.Models.Category;
using Endpoint.Database.Models.Franchise;
using Endpoint.Database.Models.Tag;
using Endpoint.GraphQL.Inputs;
using HotChocolate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Endpoint.GraphQL;

public sealed class Mutation
{
    public Task<CardModel> AddCard(CreateCardInput input, [Service] IMapper mapper, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        var command = mapper.Map<AddCardCommand>(input);
        return mediator.Send(command, cancellationToken);
    }

    public Task<TagModel> AddTag(CreateTagInput input, [Service] IMapper mapper, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        var command = mapper.Map<AddTagCommand>(input);
        return mediator.Send(command, cancellationToken);
    }

    public Task<CategoryModel> AddCategory(CreateCategoryInput input, [Service] IMapper mapper, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        var command = mapper.Map<AddCategoryCommand>(input);
        return mediator.Send(command, cancellationToken);
    }

    public Task<FranchiseModel> AddFranchise(CreateFranchiseInput input, [Service] IMapper mapper, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        var command = mapper.Map<AddFranchiseCommand>(input);
        return mediator.Send(command, cancellationToken);
    }
}
