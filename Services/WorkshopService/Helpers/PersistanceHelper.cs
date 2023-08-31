using HornyWorkshop.Domain.Database;
using HornyWorkshop.Domain.Database.Models;
using HornyWorkshop.Domain.Database.Models.Scene;
using Microsoft.EntityFrameworkCore;

namespace HornyWorkshop.Services.WorkshopService.Helpers;

internal static class PersistanceHelper
{
    internal static async ValueTask Seed(IServiceProvider provider, CancellationToken ct = default)
    {
        var factory = provider.GetRequiredService<IDbContextFactory<PersistanceContext>>();
        await using var db = await factory.CreateDbContextAsync(ct);

        await db.Database.EnsureDeletedAsync(ct);
        await db.Database.EnsureCreatedAsync(ct);

        //await SeedGames(db, ct);
        //await db.SaveChangesAsync(ct);

        //await SeedTags(db, ct);
        //await db.SaveChangesAsync(ct);

        //await SeedCards(db, ct);
        //await db.SaveChangesAsync(ct);
    }

    private static async ValueTask SeedCards(PersistanceContext context, CancellationToken ct)
    {
        var src = "https://cdn.discordapp.com/attachments/919351851550392370/1117244134911123516/autosave_2023_0322_1019_30_004.png";
        var name = "autosave_";

        var tags = await context.Tags.ToArrayAsync(ct);
        var games = await context.Games.ToArrayAsync(ct);

        await context.AddRangeAsync(Enumerable.Range(0, 100).Select(e =>
        {
            var count = Random.Shared.Next(tags.Length);

            return new SceneModel
            {
                Name = new() { En = $"{name}{e} (en)", Ru = $"{name}{e} (en)" },
                Tags = Enumerable.Range(0, count).Select(_ => tags[Random.Shared.Next(tags.Length)]).Distinct().ToList(),
                Games = Enumerable.Range(0, count).Select(_ => games[Random.Shared.Next(games.Length)]).Distinct().ToList(),
                Versions = { new SceneVersion { Cover = src } }
            };
        }), ct);
    }

    private static async ValueTask SeedTags(PersistanceContext context, CancellationToken ct)
    {
        var names = new[]
        {
            "Qu",
            "quinella",
            "Raven",
            "real",
            "realistic",
            "reality",
            "redhead",
            "red_head",
            "rei_ayanami",
            "Rias",
            "roomgirl",
            "rwby",
            "ryouji_kaji",
            "SaintPriest",
            "Sakayanagi_arisu",
            "sakura",
            "sakura",
            "Sasaki",
            "SB3",
            "scene",
            "scenes",
            "schoolgirl",
            "school_girl",
            "school_outfit",
            "score",
            "score",
            "seth",
            "Sex",
            "sexy",
            "sexy_girl",
            "sexy_woman",
            "sheva",
            "Shiemi",
            "Shigaraki_Tomura",
            "shoko_sugimoto",
            "short_hair",
            "shota",
            "shuffle",
            "silver_hair",
            "skull_girls",
        };

        await context.AddRangeAsync(names.Select(e => new TagModel { Name = new() { Ru = $"{e} (ru)", En = $"{e} (en)" } }), ct);
    }

    private static async ValueTask SeedGames(PersistanceContext context, CancellationToken ct)
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
                    }
                },
                new GameModel
                {
                    Name = new()
                    {
                        Ru = "Koikatsu Sunshae (ru)",
                        En = "Koikatsu Sunshae (en)"
                    }
                },
                new GameModel
                {
                    Name = new()
                    {
                        Ru = "Honey Select 2 (ru)",
                        En = "Honey Select 2 (en)"
                    }
                }
            }, ct);
    }
}
