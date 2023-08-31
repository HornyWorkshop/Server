using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endpoint.Database.Models.Locale;

public class LocaleConfiguration : IEntityTypeConfiguration<LocaleModel>
{
    public void Configure(EntityTypeBuilder<LocaleModel> builder)
    {
        builder.Property(p => p.Ru).HasDefaultValue(string.Empty);
        builder.Property(p => p.Kr).HasDefaultValue(string.Empty);
        builder.Property(p => p.Jp).HasDefaultValue(string.Empty);
    }
}
