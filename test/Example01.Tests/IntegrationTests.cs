using System.Net;
using FluentAssertions;

namespace Example01.Tests;

public class IntegrationTests
{
    [Theory]
    [InlineData("api/shapes")]
    [InlineData("api/shapes?type=circle")]
    [InlineData("api/shapes?type=square")]
    [InlineData("api/shapes?type=triangle")]
    [InlineData("api/shapes?type=rectangle")]
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
}