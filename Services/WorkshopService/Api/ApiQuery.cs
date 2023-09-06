using HornyWorkshop.Domain.Database;
using HornyWorkshop.Domain.Database.Models;
using HornyWorkshop.Domain.Database.Models.Card;
using HornyWorkshop.Domain.Database.Models.Scene;
using Microsoft.EntityFrameworkCore;

namespace HornyWorkshop.Services.WorkshopService.Api;

public sealed class ApiQuery
{
    #region FirstOrDefault

    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    public IQueryable<LocaleModel> Locale(PersistenceContext db) => db.Locales;

    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    public IQueryable<TagModel> Tag(PersistenceContext db) => db.Tags;

    #endregion FirstOrDefault

    public IQueryable<GameModel> Games(PersistenceContext db) => db.Games.Include(e => e.Name);

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<AuthorModel> Authors(PersistenceContext db) => db.Authors;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TagModel> Tags(PersistenceContext db) => db.Tags.Include(e => e.Name);

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<SceneModel> Scenes(PersistenceContext db) => db.Scenes.Include(e => e.Name);

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CardModel> Cards(PersistenceContext db) => db.Cards.Include(e => e.Name);

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<FranchiseModel> Franchises(PersistenceContext db) => db.Franchises.Include(e => e.Name);

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<PersonModel> Persons(PersistenceContext db) => db.Persons.Include(e => e.Name);
}
