using Example01.Application.Abstractions;
using Example01.Domain.Models;

namespace Example01.Infrastructure.Repositories;

public sealed class ShapeRepository : IShapeRepository
{
    public Task<IReadOnlyList<Shape>> GetShapesAsync(ShapeType shapeType, CancellationToken cancellationToken)
    {
        var shapes = Enumerable.Range(1, RandomNumber())
            .Select(x => GetShape(shapeType))
            .ToList();

        return Task.FromResult<IReadOnlyList<Shape>>(shapes);
    }

    private static Shape GetShape(ShapeType shapeType)
    {
        return shapeType switch
        {
            ShapeType.All => GetShape(RandomShapeType()),
            ShapeType.Circle => new Circle
            {
                Center = new Point { X = RandomNumber(), Y = RandomNumber() },
                Radius = RandomNumber()
            },
            ShapeType.Square => new Square
            {
                P1 = new Point { X = RandomNumber(), Y = RandomNumber() },
                Side = RandomNumber()
            },
            ShapeType.Triangle => new Triangle
            {
                P1 = new Point { X = RandomNumber(), Y = RandomNumber() },
                P2 = new Point { X = RandomNumber(), Y = RandomNumber() },
                P3 = new Point { X = RandomNumber(), Y = RandomNumber() }
            },
            ShapeType.Rectangle => new Rectangle
            {
                P1 = new Point { X = RandomNumber(), Y = RandomNumber() },
                Height = RandomNumber(),
                Weight = RandomNumber()
            },
            _ => throw new InvalidOperationException()
        };
    }

    private static ShapeType RandomShapeType()
    {
        return Enum.GetValues<ShapeType>()
            .Where(x => x != ShapeType.All)
            .OrderBy(_ => Guid.NewGuid())
            .First();
    }

    private static int RandomNumber(int min = 1, int max = 100)
    {
        return Random.Shared.Next(min, max);
    }
}