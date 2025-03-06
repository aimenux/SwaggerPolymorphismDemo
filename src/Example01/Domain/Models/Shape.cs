using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Example01.Domain.Models;

[SwaggerDiscriminator("type")]
[SwaggerSubType(typeof(Circle), DiscriminatorValue = nameof(ShapeType.Circle))]
[SwaggerSubType(typeof(Square), DiscriminatorValue = nameof(ShapeType.Square))]
[SwaggerSubType(typeof(Triangle), DiscriminatorValue = nameof(ShapeType.Triangle))]
[SwaggerSubType(typeof(Rectangle), DiscriminatorValue = nameof(ShapeType.Rectangle))]
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