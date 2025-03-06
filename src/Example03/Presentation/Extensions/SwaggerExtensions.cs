namespace Example03.Presentation.Extensions;

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
            options.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
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
}