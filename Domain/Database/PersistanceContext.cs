using HornyWorkshop.Domain.Database.Models;
using HornyWorkshop.Domain.Database.Models.Card;
using HornyWorkshop.Domain.Database.Models.Scene;
using Microsoft.EntityFrameworkCore;

namespace HornyWorkshop.Domain.Database;

public sealed class PersistanceContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<CardModel> Cards => Set<CardModel>();
    public DbSet<CardVersion> CardsVersions => Set<CardVersion>();

    public DbSet<SceneModel> Scenes => Set<SceneModel>();
    public DbSet<SceneVersion> ScenesVersions => Set<SceneVersion>();

    public DbSet<TagModel> Tags => Set<TagModel>();
    public DbSet<GameModel> Games => Set<GameModel>();
    public DbSet<LocaleModel> Locales => Set<LocaleModel>();
    public DbSet<AuthorModel> Authors => Set<AuthorModel>();

    public DbSet<PersonModel> Persons => Set<PersonModel>();
    public DbSet<FranchiseModel> Franchises => Set<FranchiseModel>();
}
