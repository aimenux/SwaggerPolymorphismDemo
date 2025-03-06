using Example04.Presentation.Extensions;
using Microsoft.AspNetCore.HttpLogging;

namespace Example04.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        builder.AddHttpLogging();
        builder.AddSwaggerDoc();
        builder.AddRouteOptions();
        return services;
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