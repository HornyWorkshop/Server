using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endpoint.Database.Models.Card;

public sealed class CardConfiguration : IEntityTypeConfiguration<CardModel>
{
    public void Configure(EntityTypeBuilder<CardModel> builder)
    {
    }
}
