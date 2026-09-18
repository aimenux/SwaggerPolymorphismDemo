namespace Example01.Domain.Models;

public sealed class Square : Shape
{
    public required Point P1 { get; init; }
    public required int Side { get; init; }
}