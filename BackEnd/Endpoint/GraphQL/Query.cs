using Endpoint.Database;
using Endpoint.Database.Models.Category;
using Endpoint.Database.Models.Franchise;
using Endpoint.Database.Models.Tag;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace Endpoint.GraphQL;

public sealed class Query
{
    [UseDbContext(typeof(DatabaseContext))]
    [UsePaging(MaxPageSize = 100, DefaultPageSize = 50, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<FranchiseModel> Franchises([ScopedService] DatabaseContext context) => context.Franchises;

    [UseDbContext(typeof(DatabaseContext))]
    [UsePaging(MaxPageSize = 100, DefaultPageSize = 50, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TagModel> Tags([ScopedService] DatabaseContext context) => context.Tags;

    [UseDbContext(typeof(DatabaseContext))]
    [UsePaging(MaxPageSize = 100, DefaultPageSize = 50, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CategoryModel> Categories([ScopedService] DatabaseContext context) => context.Categories;
}
