using Example01.Application;
using Example01.Infrastructure;
using Example01.Presentation;
using Example01.Presentation.Extensions;

namespace Example01;

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