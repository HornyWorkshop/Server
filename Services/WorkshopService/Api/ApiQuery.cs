using HornyWorkshop.Domain.Database;
using HornyWorkshop.Domain.Database.Models;
using HornyWorkshop.Domain.Database.Models.Card;
using HornyWorkshop.Domain.Database.Models.Scene;
using Microsoft.EntityFrameworkCore;

namespace HornyWorkshop.Services.WorkshopService.Api;

public sealed class ApiQuery
{
    public IQueryable<GameModel> Games(PersistanceContext db) => db.Games.Include(e => e.Name);

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<AuthorModel> Authors(PersistanceContext db) => db.Authors;

    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    public IQueryable<LocaleModel> Locale(PersistanceContext db) => db.Locales;

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TagModel> Tags(PersistanceContext db) => db.Tags;

    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    public IQueryable<TagModel> Tag(PersistanceContext db) => db.Tags;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<SceneModel> Scenes(PersistanceContext db) => db.Scenes;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CardModel> Cards(PersistanceContext db) => db.Cards;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<FranchiseModel> Franchises(PersistanceContext db) => db.Franchises;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<PersonModel> Persons(PersistanceContext db) => db.Persons;
}
