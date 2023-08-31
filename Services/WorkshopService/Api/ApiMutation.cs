using HornyWorkshop.Domain.Database;
using HornyWorkshop.Domain.Database.Models;
using HornyWorkshop.Services.WorkshopService;
using HornyWorkshop.Services.WorkshopService.DataTypes;
using HornyWorkshop.Services.WorkshopService.Extensions;
using HornyWorkshop.Services.WorkshopService.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HornyWorkshop.Services.WorkshopService.Api;

internal readonly record struct IconValue(IFile File, int Index);

public sealed class ApiMutation
{
    private readonly IDbContextFactory<PersistanceContext> _factory;
    private static readonly int[] _sizes = new[] { 16, 24, 32, 48, 64, 96, 128, 192, 256 };

    public ApiMutation(IDbContextFactory<PersistanceContext> factory) => _factory = factory;

    private static async ValueTask<bool> ValidateSize(IconValue icon, Dictionary<int, bool> sizes, CancellationToken ct)
    {
        var image = await Image.LoadAsync(icon.File.OpenReadStream(), ct);
        if (image.Width != image.Height) return false;

        if (sizes.TryGetValue(image.Width, out var used) is false || used is true) return false;
        sizes[image.Width] = true;

        return false;
    }

    private static async ValueTask ValidateSizes(IEnumerable<IconValue> icons, CancellationToken ct)
    {
        var sizes = _sizes.ToDictionary(e => e, _ => false);

        if (await icons.AllAsync(e => ValidateSize(e, sizes, ct), ct) is false)
            throw new ApplicationException();

        if (sizes.All(e => e.Value) is false)
            throw new ApplicationException();
    }

    private static async ValueTask SaveIcons(int id, IEnumerable<IFile> icons, CancellationToken ct)
    {
        var dir = System.IO.Path.Combine(Defaults.AssetsDirectory.FullName, "icons", "games", id.ToString());
        Directory.CreateDirectory(dir);

        await Parallel.ForEachAsync(icons, ct, async (x, ct) =>
        {
            var image = await Image.LoadAsync(x.OpenReadStream(), ct);

            var offset = Array.FindIndex(_sizes, e => e == image.Width);

            var path = System.IO.Path.Combine(dir, $"{1 + offset}.webp");

            await image.SaveAsWebpAsync(path, ct);
        });
    }

    [GraphQLDescription("Add new Game")]
    public async ValueTask<GameModel> CreateGame(CreateGameInput payload, CancellationToken ct)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);

        if (payload.Icons.Count == 9)
            throw new ApplicationException();

        await ValidateSizes(payload.Icons.Select((e, i) => new IconValue { File = e, Index = i }), ct);

        var model = new GameModel();
        MapperHelper.Lang(model.Name, payload.Name);

        await db.Games.AddAsync(model, ct);
        await db.SaveChangesAsync(ct);

        await SaveIcons(model.Id, payload.Icons, ct);

        return model;
    }

    [GraphQLDescription("Edit the Game")]
    public async ValueTask<GameModel> UpdateGame(EditGameInput payload, CancellationToken ct)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);

        var model = await db.Games.FirstAsync(ct);

        MapperHelper.LangIfNotNull(model.Name, payload.Name);

        if (payload.File is not null)
        {

        }

        db.Games.Update(model);
        await db.SaveChangesAsync(ct);

        return model;
    }
}