namespace Example04.Domain.Models;

public sealed class Rectangle : Shape
{
    public required Point P1 { get; init; }
    public required int Height { get; init; }
    public required int Width { get; init; }
}