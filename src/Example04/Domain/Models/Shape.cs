using System.Text.Json.Serialization;

namespace Example04.Domain.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization)]
[JsonDerivedType(typeof(Circle), nameof(Circle))]
[JsonDerivedType(typeof(Square), nameof(Square))]
[JsonDerivedType(typeof(Triangle), nameof(Triangle))]
[JsonDerivedType(typeof(Rectangle), nameof(Rectangle))]
public abstract class Shape
{
    public Color Color { get; init; }
}