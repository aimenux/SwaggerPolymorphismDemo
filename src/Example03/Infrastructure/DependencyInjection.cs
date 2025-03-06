using Example03.Application.Abstractions;
using Example03.Infrastructure.Repositories;

namespace Example03.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IShapeRepository, ShapeRepository>();
        return services;
    }
}