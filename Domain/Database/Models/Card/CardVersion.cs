using HornyWorkshop.Domain.Database.Models.BinaryFile;

namespace HornyWorkshop.Domain.Database.Models.Card;

public class CardVersion
{
    public int Id { get; init; }

    public string Cover { get; init; } = string.Empty;

    public BinaryFileModel File { get; init; } = BinaryFileModel.Empty;
}
