using Endpoint.Database.Models.Chunk;
using System.Collections.Generic;

namespace Endpoint.Database.Models.File;

public class FileModel
{
    public int Id { get; init; }
    public byte[] Checksum { get; init; } = default!;
    public string Name {  get; init; } = default!;

    public virtual IReadOnlyList<ChunkModel> Chunks { get; init; } = default!;
}
