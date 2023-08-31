using Endpoint.Application.Commands.Franchise;
using Endpoint.Database;
using Endpoint.Database.Models.Franchise;
using Endpoint.Database.Models.Locale;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Endpoint.Application.Handlers.Franchise;

public sealed class AddFranchiseHandler : IRequestHandler<AddFranchiseCommand, FranchiseModel>
{
    public async Task<FranchiseModel> Handle(AddFranchiseCommand request, CancellationToken cancellationToken)
    {
        await using var context = await _factory.CreateDbContextAsync(cancellationToken);

        var value = context.Franchises.Add(new FranchiseModel
        {
            Name = new LocaleModel
            {
                Ru = request.Name.Ru,
                En = request.Name.En,
                Kr = request.Name.Kr,
                Jp = request.Name.Jp,
            },
            Tags = context.Tags.Where(tag => request.Tags.Contains(tag.Id)).Include(i => i.Name).ToArray()
        }).Entity;

        await context.SaveChangesAsync(cancellationToken);

        return value;
    }

    public AddFranchiseHandler(IDbContextFactory<DatabaseContext> factory) => _factory = factory;

    private readonly IDbContextFactory<DatabaseContext> _factory;
}
