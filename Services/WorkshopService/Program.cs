using HornyWorkshop.Domain.Database;
using HornyWorkshop.Server.Domain.Database.DataTypes;
using HornyWorkshop.Services.WorkshopService;
using HornyWorkshop.Services.WorkshopService.Api;
using HornyWorkshop.Services.WorkshopService.BackgroundServices.TelegramServices;
using HornyWorkshop.Services.WorkshopService.DataTypes;
using HornyWorkshop.Services.WorkshopService.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Threading.Channels;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddSingleton<ITelegramBotClient>(new TelegramBotClient("5970352724:AAG3exzkzjoHDcBw0E_J7xqM-eOxO7GttYc"));

var gql = builder.Services.AddGraphQLServer();
gql.ModifyRequestOptions(opt => opt.IncludeExceptionDetails = builder.Environment.IsDevelopment());
gql.AddQueryType<ApiQuery>();
gql.AddMutationType<ApiMutation>();
gql.AddType<UploadType>();
gql.RegisterDbContext<PersistenceContext>(DbContextKind.Pooled);
gql.AddProjections();
gql.AddFiltering();
gql.AddSorting();

gql.BindRuntimeType<GameFeatures, IntType>();
gql.AddTypeConverter<GameFeatures, int>(e => (int)e);

// builder.Services.AddPooledDbContextFactory<PersistanceContext>(e => e.UseInMemoryDatabase("horny"));
builder.Services.AddPooledDbContextFactory<PersistenceContext>(e => e.UseNpgsql("Database=horny;User Id=postgres;Host=db;Port=5432"));

builder.Services.AddSingleton<Channels>();

var channel = Channel.CreateUnbounded<UploadItem>();
builder.Services.AddSingleton(channel);
builder.Services.AddSingleton(channel.Reader);
builder.Services.AddSingleton(channel.Writer);

builder.Services.AddHostedService<TelegramLifetimeService>();
builder.Services.AddHostedService<TelegramLifetimeService>();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Defaults.AssetsDirectory.FullName),
    RequestPath = "/assets"
});

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Defaults.UploadsDirectory.FullName),
    RequestPath = "/uploads"
});

app.UseCors(e => e.AllowAnyOrigin().AllowAnyHeader());
app.MapGraphQL();
app.MapBananaCakePop();


await PersistenceHelper.Seed(app.Services);

await app.RunAsync();
