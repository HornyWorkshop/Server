using HornyWorkshop.Domain.Database.Models.Card;
using HornyWorkshop.Domain.Database.Models.Scene;

namespace HornyWorkshop.Domain.Database.Models;

public sealed class TagModel
{
    public int Id { get; init; }

    public LocaleModel Name { get; init; } = LocaleModel.Empty;

    public ICollection<CardModel> Cards { get; init; } = new List<CardModel>();
    public ICollection<SceneModel> Scenes { get; init; } = new List<SceneModel>();
}
