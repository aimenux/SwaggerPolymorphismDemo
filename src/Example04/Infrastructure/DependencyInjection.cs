using Example04.Application.Abstractions;
using Example04.Infrastructure.Repositories;

namespace Example04.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IShapeRepository, ShapeRepository>();
        return services;
    }
}