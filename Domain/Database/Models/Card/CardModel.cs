namespace HornyWorkshop.Domain.Database.Models.Card;

public sealed class CardModel
{
    public int Id { get; init; }

    public LocaleModel Locale { get; init; } = LocaleModel.Empty;
    public AuthorModel Author { get; init; } = AuthorModel.Empty;

    public ICollection<TagModel> Tags { get; init; } = new List<TagModel>();
    public ICollection<GameModel> Games { get; init; } = new List<GameModel>();
    public ICollection<CardVersion> Versions { get; init; } = new List<CardVersion>();
}
