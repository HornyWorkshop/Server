namespace HornyWorkshop.Domain.Database.Models.BinaryFile;

public sealed class BinaryFileChunk
{
    public int Id { get; init; }

    public string Url { get; init; } = string.Empty;
    public string Hash { get; init; } = string.Empty;
}
