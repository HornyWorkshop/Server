using System;
using System.Reflection;
using System.Threading.Tasks.Dataflow;
using Endpoint.Application.Commands.Card;
using Endpoint.Application.Commands.Franchise;
using Endpoint.Application.Commands.Tag;
using Endpoint.Database;
using Endpoint.Discord;
using Endpoint.GraphQL;
using Endpoint.GraphQL.Inputs;
using GraphQL.Server.Ui.Playground;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Endpoint;

public sealed class Startup
{
    public Startup(IConfiguration configuration, IHostEnvironment environment) =>
        (_configuration, _environment) = (configuration, environment);

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddProjections()
            .AddFiltering()
            .AddSorting()
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = _environment.IsDevelopment());

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(config =>
        {
            config.CreateMap<CreateTagInput, AddTagCommand>();
            config.CreateMap<CreateCardInput, AddCardCommand>();
            config.CreateMap<CreateFranchiseInput, AddFranchiseCommand>();
        });

        services.AddSingleton<BufferBlock<DiscordUpload>>();

        services.AddTransient<DiscordSocketClientFactory>();
        services.AddTransient(provider => provider.GetRequiredService<DiscordSocketClientFactory>().Create().GetAwaiter().GetResult());

        services.AddScoped(p => p.GetRequiredService<IDbContextFactory<DatabaseContext>>().CreateDbContext());

        services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();

        services.AddControllers();

        var dbConnectionString = _configuration.GetConnectionString("Database");
        if (dbConnectionString is null) throw new ApplicationException();

        services.AddPooledDbContextFactory<DatabaseContext>((provider, options) => options
            .UseNpgsql(dbConnectionString)
            .UseLoggerFactory(provider.GetRequiredService<ILoggerFactory>())
            .EnableSensitiveDataLogging(_environment.IsDevelopment()), 20);

        //services.AddAuthentication()
        ////services.AddAuthentication(configure =>
        ////{
        ////    configure.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        ////    configure.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        ////    configure.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        ////    configure.DefaultScheme = DiscordAuthenticationDefaults.AuthenticationScheme;
        ////})
        ////.AddCookie(configure =>
        ////{
        ////    configure.LoginPath = new PathString("/api/auth/sign-in/Discord");
        ////})
        ////.AddJwtBearer(configure =>
        ////{
        ////    configure.TokenValidationParameters = new TokenValidationParameters
        ////    {
        ////        ValidateIssuer = Configuration.GetValue<bool>("Jwt:ValidateIssuer"),
        ////        ValidateAudience = Configuration.GetValue<bool>("Jwt:ValidateAudience"),
        ////        ValidateIssuerSigningKey = true,
        ////        ValidIssuer = Configuration.GetValue<string>("Jwt:Issuer"),
        ////        ValidAudience = Configuration.GetValue<string>("Jwt:Audience"),
        ////        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:SigningKey")))
        ////    };
        ////})
        //.AddDiscord(configuration =>
        //{
        //    configuration.ClientId = _configuration.GetValue<string>("Discord:ClientId");
        //    configuration.ClientSecret = _configuration.GetValue<string>("Discord:ClientSecret");
        //})
        //.AddCookie(configure => configure.LoginPath = new PathString("/api/auth/sign-in/Discord"));

        //.AddEntityFrameworkStores<DatabaseContext>();

        //services.AddIdentity<UserModel, IdentityRole>()
        //    .AddEntityFrameworkStores<DatabaseContext>();


        //services.AddSwaggerGen(setup => setup
        //    .SwaggerDoc("v1", new OpenApiInfo { Title = "Endpoint", Version = "v1" }));

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
        if (_environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseGraphQLPlayground(/*new PlaygroundOptions
            { 
                QueryPath = "/graphql",
                Path = "/playground"
            }*/);
            // app.UsePlayground(new PlaygroundOptions
            // { 
            //     QueryPath = "/graphql",
            //     Path = "/playground"
            // });
            //app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Endpoint v1"));
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        }

        // app.UseHttpsRedirection();

        app.UseRouting();

        // app.UseAuthentication();
        // app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGraphQL();
        });
    }

    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _environment;
}
