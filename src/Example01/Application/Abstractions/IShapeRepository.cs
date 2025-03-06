using Example01.Domain.Models;

namespace Example01.Application.Abstractions;

public interface IShapeRepository
{
    Task<IReadOnlyList<Shape>> GetShapesAsync(ShapeType shapeType, CancellationToken cancellationToken);
}