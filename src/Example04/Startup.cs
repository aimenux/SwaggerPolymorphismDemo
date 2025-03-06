using Example04.Application;
using Example04.Infrastructure;
using Example04.Presentation;
using Example04.Presentation.Endpoints;
using Example04.Presentation.Extensions;

namespace Example04;

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