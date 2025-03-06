using Example03.Application;
using Example03.Infrastructure;
using Example03.Presentation;
using Example03.Presentation.Endpoints;
using Example03.Presentation.Extensions;

namespace Example03;

public class Startup
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder
            .AddPresentation()
            .AddApplication()
            .AddInfrastructure();
    }

    public void Configure(WebApplication app)
    {
        app.UseHttpLogging();
        app.UseSwaggerDoc();
        app.UseHttpsRedirection();
        app.MapShapesEndpoints();
    }
}