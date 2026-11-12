using System.Net;
using System.Text.Json;
using AwesomeAssertions;

namespace Example02.Tests;

public class IntegrationTests
{
    [Theory]
    [InlineData("api/shapes")]
    [InlineData("api/shapes?shape-type=circle")]
    [InlineData("api/shapes?shape-type=square")]
    [InlineData("api/shapes?shape-type=triangle")]
    [InlineData("api/shapes?shape-type=rectangle")]
    public async Task Should_Get_Shapes(string route)
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("circle", "Circle")]
    [InlineData("square", "Square")]
    [InlineData("triangle", "Triangle")]
    [InlineData("rectangle", "Rectangle")]
    public async Task Should_Return_Shapes_Matching_Discriminator_Type(string shapeTypeQuery, string expectedType)
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        using var response = await client.GetAsync($"api/shapes?shape-type={shapeTypeQuery}");
        using var document = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
        var shapes = document.RootElement.EnumerateArray().ToList();

        // assert
        shapes.Should().NotBeEmpty();
        shapes.Should().OnlyContain(shape => shape.GetProperty("type").GetString() == expectedType);
        shapes.Should().OnlyContain(shape => HasExpectedDiscriminatedProperties(shape, expectedType));
    }

    [Theory]
    [InlineData("99")]
    [InlineData("-1")]
    [InlineData("unknown")]
    public async Task Should_Return_No_Shapes_For_Undefined_Shape_Type(string shapeTypeQuery)
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        using var response = await client.GetAsync($"api/shapes?shape-type={shapeTypeQuery}");
        using var document = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        document.RootElement.EnumerateArray().Should().BeEmpty();
    }

    private static bool HasExpectedDiscriminatedProperties(JsonElement shape, string expectedType)
    {
        return expectedType switch
        {
            "Circle" => shape.TryGetProperty("center", out _) && shape.TryGetProperty("radius", out _)
                && !shape.TryGetProperty("p1", out _) && !shape.TryGetProperty("side", out _),
            "Square" => shape.TryGetProperty("p1", out _) && shape.TryGetProperty("side", out _)
                && !shape.TryGetProperty("center", out _) && !shape.TryGetProperty("height", out _),
            "Triangle" => shape.TryGetProperty("p1", out _) && shape.TryGetProperty("p2", out _) && shape.TryGetProperty("p3", out _)
                && !shape.TryGetProperty("center", out _) && !shape.TryGetProperty("side", out _),
            "Rectangle" => shape.TryGetProperty("p1", out _) && shape.TryGetProperty("height", out _) && shape.TryGetProperty("width", out _)
                && !shape.TryGetProperty("center", out _) && !shape.TryGetProperty("p2", out _),
            _ => false
        };
    }
}