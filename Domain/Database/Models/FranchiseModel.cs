using HornyWorkshop.Domain.Database.Models.Card;

namespace HornyWorkshop.Domain.Database.Models;

public class FranchiseModel
{
    public int Id { get; init; }

    public virtual ICollection<CardModel> Cards { get; init; } = new List<CardModel>();
}
