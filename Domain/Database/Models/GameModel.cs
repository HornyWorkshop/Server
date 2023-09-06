using HornyWorkshop.Domain.Database.Models.Card;
using HornyWorkshop.Domain.Database.Models.Scene;
using HornyWorkshop.Server.Domain.Database.DataTypes;

namespace HornyWorkshop.Domain.Database.Models;

public sealed class GameModel
{
    public int Id { get; init; }

    public string Magnet { get; init; } = string.Empty;
    public GameFeatures Features { get; set; } = GameFeatures.None;

    public ICollection<CardModel> Cards { get; init; } = new List<CardModel>();
    public ICollection<SceneModel> Scenes { get; init; } = new List<SceneModel>();
    // public ICollection<PluginModel> Plugins { get; init; } = new List<PluginModel>();

    public LocaleModel Name { get; init; } = LocaleModel.Empty;
}
