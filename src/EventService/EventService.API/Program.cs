using EventService.API.Endpoints;
using EventService.Domain;
using EventService.Infrastructure;

namespace EventService.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddInfrastructure()
            .AddDomain();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        await app.ApplyMigrations();
        app.AddEndpoints();

        app.Run();
    }
}
