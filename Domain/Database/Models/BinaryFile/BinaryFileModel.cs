namespace HornyWorkshop.Domain.Database.Models.BinaryFile;

public sealed class BinaryFileModel
{
    public int Id { get; init; }

    public ICollection<BinaryFileVersion> Versions { get; init; } = new List<BinaryFileVersion>();

    internal static BinaryFileModel Empty => new();
}
