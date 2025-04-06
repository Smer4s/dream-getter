using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace UserService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swagger =>
        {
            swagger.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. " +
                "\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below." +
                "\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });

            var (securityScheme, array) = new ValueTuple<OpenApiSecurityScheme, IList<string>>(
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme,
                    },
                },
                Array.Empty<string>());

            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                { securityScheme, array },
            });
        });


        return services;
    }
}
