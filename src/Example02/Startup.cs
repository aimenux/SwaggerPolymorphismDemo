using Example02.Application;
using Example02.Infrastructure;
using Example02.Presentation;
using Example02.Presentation.Extensions;

namespace Example02;

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
        app.UseAuthorization();
        app.MapControllers();
    }
}