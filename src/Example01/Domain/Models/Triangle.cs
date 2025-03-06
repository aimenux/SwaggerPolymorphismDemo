namespace Example01.Domain.Models;

public sealed class Triangle() : Shape(nameof(ShapeType.Triangle))
{
    public required Point P1 { get; init; }
    public required Point P2 { get; init; }
    public required Point P3 { get; init; }
}