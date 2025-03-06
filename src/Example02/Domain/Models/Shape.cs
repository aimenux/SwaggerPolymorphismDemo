using System.Text.Json.Serialization;

namespace Example02.Domain.Models;

[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization)]
[JsonDerivedType(typeof(Circle), nameof(Circle))]
[JsonDerivedType(typeof(Square), nameof(Square))]
[JsonDerivedType(typeof(Triangle), nameof(Triangle))]
[JsonDerivedType(typeof(Rectangle), nameof(Rectangle))]
public abstract class Shape(string type)
{
    public string Type { get; init; } = type;

    public Color Color { get; init; }
}