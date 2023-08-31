using Endpoint.Database.Models;
using Endpoint.Database.Models.Card;
using Endpoint.Database.Models.Category;
using Endpoint.Database.Models.Chunk;
using Endpoint.Database.Models.File;
using Endpoint.Database.Models.Franchise;
using Endpoint.Database.Models.Locale;
using Endpoint.Database.Models.Person;
using Endpoint.Database.Models.Tag;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Endpoint.Database;

public sealed class DatabaseContext : IdentityDbContext<UserModel>
{
    public DbSet<CardModel> Cards { get; set; } = default!;
    public DbSet<FranchiseModel> Franchises { get; set; } = default!;
    public DbSet<CharacterModel> Persons { get; set; } = default!;
    public DbSet<TagModel> Tags { get; set; } = default!;
    public DbSet<LocaleModel> Locales { get; set; } = default!;
    public DbSet<CategoryModel> Categories { get; set; } = default!;
    public DbSet<FileModel> Files { get; set; } = default!;
    public DbSet<ChunkModel> Chunks { get; set; } = default!;
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CardConfiguration());
        builder.ApplyConfiguration(new FranchiseConfiguration());
        builder.ApplyConfiguration(new CharacterConfiguration());
        builder.ApplyConfiguration(new TagConfiguration());
        builder.ApplyConfiguration(new LocaleConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());

        base.OnModelCreating(builder);
    }
}
