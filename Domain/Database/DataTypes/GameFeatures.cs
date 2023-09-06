namespace HornyWorkshop.Server.Domain.Database.DataTypes;

[Flags]
public enum GameFeatures
{
    None = 0,
    Cards = 1,
    Scenes = 2,
    Plugins = 4,
    ZipMods = 8
}
