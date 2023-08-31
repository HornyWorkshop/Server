using Endpoint.Commons;
using Endpoint.Database.Models.Franchise;
using Endpoint.Database.Models.Person;
using Endpoint.Database.Models.Tag;
using System.Collections.Generic;

namespace Endpoint.Database.Models.Locale;

public class LocaleModel : ILocaleValue
{
    public int Id { get; init; }
    public string Ru { get; set; } = default!;
    public string En { get; set; } = default!;
    public string Kr { get; set; } = default!;
    public string Jp { get; set; } = default!;

    public virtual ICollection<CharacterModel> Persons { get; init; } = default!;
    public virtual ICollection<FranchiseModel> Franchises { get; init; } = default!;
    public virtual ICollection<TagModel> Tags { get; init; } = default!;
}
