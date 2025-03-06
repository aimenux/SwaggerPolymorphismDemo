using Example03.Application.Services;
using Example03.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example03.Presentation.Endpoints;

public static class ShapesEndpoints
{
    public static IEndpointRouteBuilder MapShapesEndpoints(this IEndpointRouteBuilder app)
    {
        app
            .MapGroup(Routes.ShapesRoute)
            .MapGetShapesEndpoint()
            .WithTags("Shapes");

        return app;
    }

    private static RouteHandlerBuilder MapGetShapesEndpoint(this IEndpointRouteBuilder app)
    {
        return app
            .MapGet("", async (IShapeService shapeService, [FromQuery(Name = "type")] string? shapeType, CancellationToken cancellationToken) =>
            {
                var shapes = await shapeService.GetShapesAsync(shapeType, cancellationToken);
                return Results.Ok(shapes);
            })
            .Produces<Shape[]>()
            .WithName("GetShapes");
    }
}