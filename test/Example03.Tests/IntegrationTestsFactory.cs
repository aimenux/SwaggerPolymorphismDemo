using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Example03.Tests;

public class IntegrationTestsFactory : WebApplicationFactory<Startup>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment(Environments.Development);

        builder.ConfigureAppConfiguration((_, configBuilder) =>
        {
        });

        builder.ConfigureTestServices(services =>
        {
        });
    }
}