using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BattleshipChallengeApi.Tests.Fixtures
{
    public class ControllerFixtureBase : WebApplicationFactory<LocalEntryPoint>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("narrow-integration-test");
            base.ConfigureWebHost(builder);
        }
    }
}
