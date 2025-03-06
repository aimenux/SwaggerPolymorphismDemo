using Example02.Application.Services;

namespace Example02.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IShapeService, ShapeService>();
        return services;
    }
}