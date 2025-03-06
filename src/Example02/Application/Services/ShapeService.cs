﻿using Example02.Application.Abstractions;
using Example02.Domain.Models;

namespace Example02.Application.Services;

public sealed class ShapeService : IShapeService
{
    private readonly IShapeRepository _shapeRepository;

    public ShapeService(IShapeRepository shapeRepository)
    {
        _shapeRepository = shapeRepository;
    }

    public async Task<IReadOnlyList<Shape>> GetShapesAsync(string? shapeType, CancellationToken cancellationToken)
    {
        shapeType ??= nameof(ShapeType.All);
        
        if (!Enum.TryParse(shapeType, true, out ShapeType shapeEnumType))
        {
            return [];
        }
        
        var shapes = await _shapeRepository.GetShapesAsync(shapeEnumType, cancellationToken);
        return shapes;
    }
}