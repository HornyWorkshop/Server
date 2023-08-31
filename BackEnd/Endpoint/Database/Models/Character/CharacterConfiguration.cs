using Endpoint.Database.Models.Tag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endpoint.Database.Models.Person;

public class CharacterConfiguration : IEntityTypeConfiguration<TagModel>
{
    public void Configure(EntityTypeBuilder<TagModel> builder)
    {
    }
}
