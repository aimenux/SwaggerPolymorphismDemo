using Example04.Domain.Models;

namespace Example04.Presentation.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwaggerDoc(this WebApplicationBuilder builder)
    {
        if (!builder.Environment.IsDevelopment())
        {
            return;
        }

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.UseOneOfForPolymorphism();
            options.SelectDiscriminatorNameUsing(GetDiscriminatorName);
            options.SelectDiscriminatorValueUsing(subType => subType.Name);
            options.SelectSubTypesUsing(baseType => baseType == typeof(Shape)
                ? [typeof(Circle), typeof(Square), typeof(Triangle), typeof(Rectangle)]
                : []);
        });
    }

    public static void UseSwaggerDoc(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DisplayRequestDuration();
        });
    }

    private static string? GetDiscriminatorName(Type baseType)
    {
        return baseType == typeof(Shape)
            ? nameof(Shape.Type).ToLowerInvariant()
            : null;
    }
}