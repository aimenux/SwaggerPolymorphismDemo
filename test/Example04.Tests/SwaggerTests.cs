using System.Net;
using System.Text.Json;
using AwesomeAssertions;

namespace Example04.Tests;

public class SwaggerTests
{
    private const string SwaggerDocumentRoute = "swagger/v1/swagger.json";

    [Fact]
    public async Task Should_Get_Swagger_Document()
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        using var response = await client.GetAsync(SwaggerDocumentRoute);

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
    }

    [Fact]
    public async Task Should_Describe_Get_Shapes_Operation_With_Shape_Type_Query_Parameter()
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        using var document = await GetSwaggerDocumentAsync(client);

        // assert
        var operation = document.RootElement.GetProperty("paths").GetProperty("/api/shapes").GetProperty("get");
        operation.GetProperty("parameters").EnumerateArray()
            .Should().Contain(parameter =>
                parameter.GetProperty("name").GetString() == "shape-type"
                && parameter.GetProperty("in").GetString() == "query");
    }

    [Fact]
    public async Task Should_Return_Array_Of_Any_Shape_Subtype_From_Get_Shapes_Operation()
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        using var document = await GetSwaggerDocumentAsync(client);

        // assert
        var schema = document.RootElement
            .GetProperty("paths").GetProperty("/api/shapes").GetProperty("get")
            .GetProperty("responses").GetProperty("200")
            .GetProperty("content").GetProperty("application/json")
            .GetProperty("schema");
        schema.GetProperty("type").GetString().Should().Be("array");
        schema.GetProperty("items").GetProperty("oneOf").EnumerateArray()
            .Select(subType => subType.GetProperty("$ref").GetString())
            .Should().BeEquivalentTo(
            [
                "#/components/schemas/Circle",
                "#/components/schemas/Square",
                "#/components/schemas/Triangle",
                "#/components/schemas/Rectangle"
            ]);
    }

    [Theory]
    [InlineData("Shape")]
    [InlineData("Circle")]
    [InlineData("Square")]
    [InlineData("Triangle")]
    [InlineData("Rectangle")]
    public async Task Should_Declare_Shape_Schemas_In_Swagger_Document(string schemaName)
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        using var document = await GetSwaggerDocumentAsync(client);

        // assert
        document.RootElement.GetProperty("components").GetProperty("schemas")
            .TryGetProperty(schemaName, out _).Should().BeTrue();
    }

    [Fact]
    public async Task Should_Document_Shape_Polymorphism_With_Discriminator()
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        using var document = await GetSwaggerDocumentAsync(client);

        // assert
        var shapeSchema = document.RootElement.GetProperty("components").GetProperty("schemas").GetProperty("Shape");
        var discriminator = shapeSchema.GetProperty("discriminator");
        discriminator.GetProperty("propertyName").GetString().Should().Be("type");

        var mapping = discriminator.GetProperty("mapping");
        mapping.GetProperty("Circle").GetString().Should().Be("#/components/schemas/Circle");
        mapping.GetProperty("Square").GetString().Should().Be("#/components/schemas/Square");
        mapping.GetProperty("Triangle").GetString().Should().Be("#/components/schemas/Triangle");
        mapping.GetProperty("Rectangle").GetString().Should().Be("#/components/schemas/Rectangle");
    }

    private static async Task<JsonDocument> GetSwaggerDocumentAsync(HttpClient client)
    {
        using var response = await client.GetAsync(SwaggerDocumentRoute);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        return await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
    }
}
