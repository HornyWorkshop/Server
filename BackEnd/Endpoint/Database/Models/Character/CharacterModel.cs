using Endpoint.Database.Models.Category;
using Endpoint.Database.Models.Franchise;
using Endpoint.Database.Models.Locale;
using Endpoint.Database.Models.Tag;
using System.Collections.Generic;

namespace Endpoint.Database.Models.Person;

public class CharacterModel
{
    public int Id { get; init; }

    public virtual LocaleModel Name { get; init; } = default!;
    public virtual ICollection<FranchiseModel> Franchises { get; set; } = default!;
    public virtual ICollection<TagModel> Tags { get; set; } = default!;
    public virtual ICollection<CategoryModel> Categories { get; set; } = default!;
}
