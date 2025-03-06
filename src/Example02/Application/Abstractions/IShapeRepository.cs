using Example02.Domain.Models;

namespace Example02.Application.Abstractions;

public interface IShapeRepository
{
    Task<IReadOnlyList<Shape>> GetShapesAsync(ShapeType shapeType, CancellationToken cancellationToken);
}