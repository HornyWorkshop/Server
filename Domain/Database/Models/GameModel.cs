namespace HornyWorkshop.Domain.Database.Models;

public sealed class GameModel
{
    public int Id { get; init; }

    public string Magnet { get; init; } = string.Empty;

    public LocaleModel Name { get; init; } = LocaleModel.Empty;
}
