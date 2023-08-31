using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endpoint.Database.Models.Category;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
{
    public void Configure(EntityTypeBuilder<CategoryModel> builder)
    {
    }
}
