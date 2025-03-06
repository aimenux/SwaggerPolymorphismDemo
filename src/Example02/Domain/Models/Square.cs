namespace Example02.Domain.Models;

public sealed class Square() : Shape(nameof(ShapeType.Square))
{
    public required Point P1 { get; init; }
    public required int Side { get; init; }
}