using Example04.Application.Services;

namespace Example04.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IShapeService, ShapeService>();
        return services;
    }
}