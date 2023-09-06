namespace HornyWorkshop.Domain.Database.Models.BinaryFile;

public sealed class BinaryFileVersion
{
    public int Id { get; init; }
    
    public string Backup { get; init; } = string.Empty;

    public ICollection<BinaryFileChunk> Chunks { get; init; } = Array.Empty<BinaryFileChunk>();
}
