using Endpoint.Database.Models.Category;
using Endpoint.Database.Models.Locale;
using Endpoint.Database.Models.Tag;
using System.Collections.Generic;

namespace Endpoint.Database.Models.Franchise;

public class FranchiseModel
{
    public int Id { get; init; }

    public virtual LocaleModel Name { get; init; } = default!;
    public virtual ICollection<TagModel> Tags { get; init; } = default!;
    public virtual ICollection<CategoryModel> Categories { get; set; } = default!;
}
