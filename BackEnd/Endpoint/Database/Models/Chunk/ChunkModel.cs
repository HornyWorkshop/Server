namespace Endpoint.Database.Models.Chunk;

public class ChunkModel
{
    public int Id { get; init; }
    public string Url { get; init; } = default!;
    public byte[] Checksum { get; init; } = default!;
}
