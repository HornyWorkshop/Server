using Endpoint.Commons;
using Endpoint.Database.Models.Category;
using MediatR;

namespace Endpoint.Application.Commands.Category;

public sealed record AddCategoryCommand : IRequest<CategoryModel>
{
    public LocaleValue Name { get; set; } = default!;
}