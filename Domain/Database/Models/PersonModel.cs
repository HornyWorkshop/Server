using HornyWorkshop.Domain.Database.Models.Card;
using HornyWorkshop.Domain.Database.Models.Scene;

namespace HornyWorkshop.Domain.Database.Models;

public class PersonModel
{
    public int Id { get; init; }

    public LocaleModel Name { get; init; } = LocaleModel.Empty;

    public virtual ICollection<CardModel> Cards { get; init; } = new List<CardModel>();
    public virtual ICollection<SceneModel> Scenes { get; init; } = new List<SceneModel>();
}
