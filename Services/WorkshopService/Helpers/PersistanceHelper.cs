using HornyWorkshop.Domain.Database;
using HornyWorkshop.Domain.Database.Models;
using HornyWorkshop.Domain.Database.Models.Card;
using HornyWorkshop.Domain.Database.Models.Scene;
using HornyWorkshop.Server.Domain.Database.DataTypes;
using HornyWorkshop.Server.HornyWorkshop.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HornyWorkshop.Services.WorkshopService.Helpers;

internal static class PersistenceHelper
{
    internal static async ValueTask Seed(IServiceProvider provider, CancellationToken ct = default)
    {
        var factory = provider.GetRequiredService<IDbContextFactory<PersistenceContext>>();
        await using var db = await factory.CreateDbContextAsync(ct);

        await db.Database.EnsureDeletedAsync(ct);
        await db.Database.EnsureCreatedAsync(ct);

        await SeedTags(db, ct);
        await SeedGames(db, ct);
        await SeedAuthors(db, ct);
        await SeedFranchises(db, ct);
        await db.SaveChangesAsync(ct);

        await SeedCards(db, ct);
        await SeedScenes(db, ct);
        await db.SaveChangesAsync(ct);
    }

    private static async ValueTask SeedScenes(PersistenceContext context, CancellationToken ct)
    {
        var src = "https://cdn.discordapp.com/attachments/919351851550392370/1117244134911123516/autosave_2023_0322_1019_30_004.png";
        var name = "autosave_";

        var tags = await context.Tags.ToArrayAsync(ct);
        var games = await context.Games.ToArrayAsync(ct);
        var authors = await context.Authors.ToArrayAsync(ct);

        await context.AddRangeAsync(Enumerable.Range(0, 64).Select(e =>
        {
            var count = Random.Shared.Next(tags.Length);

            return new SceneModel
            {
                Name = new() { En = $"{name}{e} (en)", Ru = $"{name}{e} (en)" },
                Author = authors[Random.Shared.Next(authors.Length)],

                Tags = Enumerable.Range(0, count).Select(_ => tags[Random.Shared.Next(tags.Length)]).Distinct().ToList(),
                Games = Enumerable.Range(1, count).Select(_ => games[Random.Shared.Next(games.Length)]).Distinct().ToList(),

                Versions = { new SceneVersion { Cover = src } }
            };
        }), ct);
    }

    private static async ValueTask SeedCards(PersistenceContext context, CancellationToken ct)
    {
        var src = "https://media.discordapp.net/attachments/839938598241697812/927025441066332190/8050118489ab2cbfc528607cf13242ec81c4ad52_result.webp";
        var name = System.IO.Path.GetFileNameWithoutExtension(new Uri(src).LocalPath);

        var tags = await context.Tags.ToArrayAsync(ct);
        var games = await context.Games.ToArrayAsync(ct);
        var authors = await context.Authors.ToArrayAsync(ct);

        await context.AddRangeAsync(Enumerable.Range(0, 64).Select(e =>
        {
            var count = Random.Shared.Next(tags.Length);

            return new CardModel
            {
                Name = new() { En = $"{name}{e} (en)", Ru = $"{name}{e} (en)" },
                Author = authors[Random.Shared.Next(authors.Length)],

                Tags = Enumerable.Range(0, count).Select(_ => tags[Random.Shared.Next(tags.Length)]).Distinct().ToList(),
                Games = Enumerable.Range(0, count).Select(_ => games[Random.Shared.Next(games.Length)]).Distinct().ToList(),
                Versions = { new CardVersion { Cover = src } }
            };
        }), ct);
    }

    private static async ValueTask SeedFranchises(PersistenceContext context, CancellationToken ct)
    {
        await context.AddRangeAsync(Enumerable.Range(0, 64).Select(e => new FranchiseModel { Name = new() { Ru = $"{StringHelper.RandomString(16)} (ru)", En = $"{StringHelper.RandomString(16)} (en)" } }), ct);
    }
    
    private static async ValueTask SeedAuthors(PersistenceContext context, CancellationToken ct)
    {
        await context.AddRangeAsync(Enumerable.Range(0, 64).Select(e => new AuthorModel { Name = StringHelper.RandomString(16) }), ct);
    }

    private static async ValueTask SeedTags(PersistenceContext context, CancellationToken ct)
    {
        await context.AddRangeAsync(Enumerable.Range(0, 64).Select(e => new TagModel { Name = new() { Ru = $"{StringHelper.RandomString(16)} (ru)", En = $"{StringHelper.RandomString(16)} (en)" } }), ct);
    }

    private static async ValueTask SeedGames(PersistenceContext context, CancellationToken ct)
    {
        await context.AddRangeAsync(
            new[]
            {
                new GameModel
                {
                    Name = new()
                    {
                        Ru = "Koikatsu (ru)",
                        En = "Koikatsu (en)"
                    },
                    Features =  GameFeatures.Scenes | GameFeatures.Plugins | GameFeatures.ZipMods
                },
                new GameModel
                {
                    Name = new()
                    {
                        Ru = "Koikatsu Sunshine (ru)",
                        En = "Koikatsu Sunshine (en)"
                    },
                    Features = GameFeatures.Cards |  GameFeatures.Plugins | GameFeatures.ZipMods
                },
                new GameModel
                {
                    Name = new()
                    {
                        Ru = "Honey Select 2 (ru)",
                        En = "Honey Select 2 (en)"
                    },
                    Features = GameFeatures.Cards | GameFeatures.Scenes |  GameFeatures.ZipMods
                }
            }, ct);
    }
}
