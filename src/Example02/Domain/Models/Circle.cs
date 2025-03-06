namespace Example02.Domain.Models;

public sealed class Circle() : Shape(nameof(ShapeType.Circle))
{
    public required Point Center { get; init; }
    public required int Radius { get; init; }
}