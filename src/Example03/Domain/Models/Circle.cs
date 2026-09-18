namespace Example03.Domain.Models;

public sealed class Circle : Shape
{
    public required Point Center { get; init; }
    public required int Radius { get; init; }
}