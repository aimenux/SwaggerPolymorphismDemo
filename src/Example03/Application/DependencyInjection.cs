using Example03.Application.Services;

namespace Example03.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IShapeService, ShapeService>();
        return services;
    }
}