using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endpoint.Database.Models.Franchise;

public class FranchiseConfiguration : IEntityTypeConfiguration<FranchiseModel>
{
    public void Configure(EntityTypeBuilder<FranchiseModel> builder)
    {
    }
}
