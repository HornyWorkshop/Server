namespace HornyWorkshop.Domain.Database.Models.Scene;

public sealed class SceneModel
{
    public int Id { get; init; }

    public LocaleModel Name { get; init; } = LocaleModel.Empty;
    public AuthorModel Author { get; init; } = AuthorModel.Empty;

    public ICollection<TagModel> Tags { get; init; } = new List<TagModel>();
    public ICollection<GameModel> Games { get; init; } = new List<GameModel>();
    public ICollection<SceneVersion> Versions { get; init; } = new List<SceneVersion>();

    internal static SceneModel Empty => new();
}
