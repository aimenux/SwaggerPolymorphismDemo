using Example02.Application.Abstractions;
using Example02.Infrastructure.Repositories;

namespace Example02.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IShapeRepository, ShapeRepository>();
        return services;
    }
}