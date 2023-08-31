using Endpoint.Database.Models.Franchise;
using Endpoint.Database.Models.Locale;
using Endpoint.Database.Models.Person;
using System.Collections.Generic;

namespace Endpoint.Database.Models.Category;

public class CategoryModel
{
    public int Id { get; init; }

    public virtual LocaleModel Name { get; init; } = default!;
    public virtual ICollection<FranchiseModel> Franchises { get; init; } = default!;
    public virtual ICollection<CharacterModel> Persons { get; init; } = default!;
}
