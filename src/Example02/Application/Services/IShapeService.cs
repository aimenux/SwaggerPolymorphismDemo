using Example02.Domain.Models;

namespace Example02.Application.Services;

public interface IShapeService
{
    Task<IReadOnlyList<Shape>> GetShapesAsync(string? shapeType, CancellationToken cancellationToken);
}