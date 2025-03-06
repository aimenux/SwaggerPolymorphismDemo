using Example01.Application.Abstractions;
using Example01.Infrastructure.Repositories;

namespace Example01.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IShapeRepository, ShapeRepository>();
        return services;
    }
}