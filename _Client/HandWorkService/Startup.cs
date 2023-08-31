using HandWorkService.Extensions;
using HandWorkService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace HandWorkService;

public sealed class Startup
{
    public static void ConfigureServices(IServiceCollection services) => services
        .AddInstallerChannel()
        .AddHttpClient<HttpClient>((provider, client) =>
        {
            var config = provider.GetRequiredService<IConfiguration>();
            var endpoint = config.GetValue<string>("Endpoint");

            client.BaseAddress = new Uri(endpoint);
        }).Services
        .AddCors(options => options
            .AddPolicy("AllowAll", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding")))
        .AddGrpc();

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env) => app
        .UseRouting()
        .UseGrpcWeb()
        .UseCors("AllowAll")
        .UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<InstallerService>().EnableGrpcWeb();
            endpoints.MapGrpcService<TaskService>().EnableGrpcWeb();
        });
}
