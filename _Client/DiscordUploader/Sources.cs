using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace DiscordUploader
{
    public sealed class Sources : IAsyncEnumerable<MemoryStream>
    {
        public async IAsyncEnumerator<MemoryStream> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            var file = File.OpenRead(_path);
            if (file is null) yield break;
            
            Console.WriteLine("Count: {0}", Math.Ceiling(file.Length / (double)MAX_FILE_SIZE));

            var memory = ArrayPool<byte>.Shared.Rent(MAX_FILE_SIZE);
            var offset = 0;

            int read;
            while ((read = await file.ReadAsync(memory, cancellationToken)) > 0)
            {
                await using var stream = new MemoryStream(read == MAX_FILE_SIZE ? memory : memory.Take(read).ToArray());

                offset += read;
                file.Seek(offset, SeekOrigin.Begin);

                yield return stream;
            }
        }

        public Sources(string path) => _path = path;

        private const int MAX_FILE_SIZE = 8_000_000;

        private readonly string _path;
    }
}
