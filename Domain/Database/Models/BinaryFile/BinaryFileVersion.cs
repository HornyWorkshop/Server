namespace HornyWorkshop.Domain.Database.Models.BinaryFile;

public sealed class BinaryFileVersion
{
    public int Id { get; init; }
    
    public string Cover { get; init; } = string.Empty;
    public string BackupUrl { get; init; } = string.Empty;

    public ICollection<BinaryFileChunk> Chunks { get; init; } = Array.Empty<BinaryFileChunk>();
}
