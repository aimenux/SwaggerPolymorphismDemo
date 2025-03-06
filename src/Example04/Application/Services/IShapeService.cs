using Example04.Domain.Models;

namespace Example04.Application.Services;

public interface IShapeService
{
    Task<IReadOnlyList<Shape>> GetShapesAsync(string? shapeType, CancellationToken cancellationToken);
}