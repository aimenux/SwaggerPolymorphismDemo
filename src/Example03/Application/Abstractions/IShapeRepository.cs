using Example03.Domain.Models;

namespace Example03.Application.Abstractions;

public interface IShapeRepository
{
    Task<IReadOnlyList<Shape>> GetShapesAsync(ShapeType shapeType, CancellationToken cancellationToken);
}