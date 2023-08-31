using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endpoint.Database.Models.Tag;

public class TagConfiguration : IEntityTypeConfiguration<TagModel>
{
    public void Configure(EntityTypeBuilder<TagModel> builder)
    {
    }
}
