using Endpoint.Application.Commands.Category;
using Endpoint.Database;
using Endpoint.Database.Models.Category;
using Endpoint.Database.Models.Locale;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Endpoint.Application.Handlers.Category;

public sealed class AddCategoryHandler : IRequestHandler<AddCategoryCommand, CategoryModel>
{
    public async Task<CategoryModel> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        await using var context = await _factory.CreateDbContextAsync(cancellationToken);

        var value = context.Categories.Add(new CategoryModel
        {
            Name = new LocaleModel
            {
                Ru = request.Name.Ru,
                En = request.Name.En,
                Kr = request.Name.Kr,
                Jp = request.Name.Jp,
            },
        }).Entity;

        await context.SaveChangesAsync(cancellationToken);

        return value;
    }

    public AddCategoryHandler(IDbContextFactory<DatabaseContext> factory) => _factory = factory;

    private readonly IDbContextFactory<DatabaseContext> _factory;
}
