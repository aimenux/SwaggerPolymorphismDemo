using Example04.Domain.Models;

namespace Example04.Application.Abstractions;

public interface IShapeRepository
{
    Task<IReadOnlyList<Shape>> GetShapesAsync(ShapeType shapeType, CancellationToken cancellationToken);
}