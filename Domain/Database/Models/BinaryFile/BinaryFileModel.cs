namespace HornyWorkshop.Domain.Database.Models.BinaryFile;

public sealed class BinaryFileModel
{
    public int Id { get; init; }

    internal static BinaryFileModel Empty => new();
}
