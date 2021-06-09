using BattleshipChallenge.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BattleshipChallengeApi.IntegrationTests.Fixtures
{
    public class ControllerFixtureBase : WebApplicationFactory<LocalEntryPoint>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("narrow-integration-test");
        }
    }
}