namespace Example03.Domain.Models;

public sealed class Rectangle() : Shape(nameof(ShapeType.Rectangle))
{
    public required Point P1 { get; init; }
    public required int Height { get; init; }
    public required int Weight { get; init; }
}