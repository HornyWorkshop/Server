namespace HornyWorkshop.Domain.Database.Models.Scene;

public sealed class SceneVersion
{
    public int Id { get; init; }

    public string Cover { get; init; } = string.Empty;
    public string Magnet { get; init; } = string.Empty;
}
