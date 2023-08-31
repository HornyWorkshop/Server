using Endpoint.Application.Commands.Tag;
using Endpoint.Database;
using Endpoint.Database.Models.Locale;
using Endpoint.Database.Models.Tag;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Endpoint.Application.Handlers.Tag;

public sealed class AddTagHandler : IRequestHandler<AddTagCommand, TagModel>
{
    public async Task<TagModel> Handle(AddTagCommand request, CancellationToken cancellationToken)
    {
        await using var context = await _factory.CreateDbContextAsync(cancellationToken);

        var value = context.Tags.Add(new TagModel
        {
            Name = new LocaleModel
            {
                Ru = request.Name.Ru,
                En = request.Name.En,
                Kr = request.Name.Kr,
                Jp = request.Name.Jp,
            }
        });

        await context.SaveChangesAsync(cancellationToken);

        return value.Entity;
    }
    public AddTagHandler(IDbContextFactory<DatabaseContext> factory) => _factory = factory;

    private readonly IDbContextFactory<DatabaseContext> _factory;
}
