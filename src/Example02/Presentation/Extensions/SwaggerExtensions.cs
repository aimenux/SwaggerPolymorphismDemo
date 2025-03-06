using Example02.Domain.Models;

namespace Example02.Presentation.Extensions;

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
            options.SelectSubTypesUsing(GetDiscriminatorSubTypes);
            options.SelectDiscriminatorNameUsing(GetDiscriminatorName);
            options.SelectDiscriminatorValueUsing(GetDiscriminatorValue);
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

    private static Type[] GetDiscriminatorSubTypes(Type type)
    {
        return type == typeof(Shape)
            ? [typeof(Circle), typeof(Square), typeof(Triangle), typeof(Rectangle)]
            : [];
    }

    private static string? GetDiscriminatorName(Type type)
    {
        return type == typeof(Shape)
            ? nameof(Shape.Type).ToLowerInvariant()
            : null;
    }

    private static string GetDiscriminatorValue(Type type) => type.Name;
}