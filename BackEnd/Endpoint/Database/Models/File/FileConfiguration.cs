using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endpoint.Database.Models.File;

public sealed class FileConfiguration : IEntityTypeConfiguration<FileModel>
{
    public void Configure(EntityTypeBuilder<FileModel> builder)
    {
        builder.Property(p => p.Checksum).HasDefaultValue(string.Empty);
    }
}
