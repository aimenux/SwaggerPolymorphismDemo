using Example01.Application.Services;

namespace Example01.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IShapeService, ShapeService>();
        return services;
    }
}