using Example01.Domain.Models;

namespace Example01.Application.Services;

public interface IShapeService
{
    Task<IReadOnlyList<Shape>> GetShapesAsync(string? shapeType, CancellationToken cancellationToken);
}