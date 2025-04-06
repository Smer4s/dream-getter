using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using UserService.Domain;
using UserService.Infrastructure;

namespace UserService.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddInfrastructure()
            .AddDomain()
            .AddWebApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.AddAuth();
        app.AddEndpoints();
        await app.ApplyMigrations();
        app.Run();
    }
}
