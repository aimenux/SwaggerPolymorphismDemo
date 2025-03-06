using Example01.Application.Services;
using Example01.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example01.Presentation.Controllers;

[ApiController]
[Route(Routes.ShapesRoute)]
public class ShapesController : ControllerBase
{
    private readonly IShapeService _shapeService;

    public ShapesController(IShapeService shapeService)
    {
        _shapeService = shapeService;
    }

    [HttpGet(Name = "GetShapes")]
    public async Task<IEnumerable<Shape>> GetShapesAsync([FromQuery(Name = "type")] string? shapeType, CancellationToken cancellationToken)
    {
        var shapes = await _shapeService.GetShapesAsync(shapeType, cancellationToken);
        return shapes;
    }
}
