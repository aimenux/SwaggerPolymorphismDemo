using Example03.Domain.Models;

namespace Example03.Application.Services;

public interface IShapeService
{
    Task<IReadOnlyList<Shape>> GetShapesAsync(string? shapeType, CancellationToken cancellationToken);
}