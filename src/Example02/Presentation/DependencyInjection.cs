using System.Text.Json;
using System.Text.Json.Serialization;
using Example02.Presentation.Extensions;
using Microsoft.AspNetCore.HttpLogging;

namespace Example02.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        builder.AddControllers();
        builder.AddHttpLogging();
        builder.AddSwaggerDoc();
        builder.AddRouteOptions();
        return services;
    }
    
    private static void AddControllers(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            });
    }
    
    private static void AddHttpLogging(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.All;
            logging.CombineLogs = true;
        });
    }
    
    private static void AddRouteOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });
    }
}