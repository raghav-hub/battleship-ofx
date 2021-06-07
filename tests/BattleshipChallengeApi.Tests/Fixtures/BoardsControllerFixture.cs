using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace BattleshipChallengeApi.Tests.Fixtures
{
    public class BoardsControllerFixture : ControllerFixtureBase
    {
        protected HttpClient _apiCaller;
        protected HttpResponseMessage _result;
        public void CreateSut()
        {
            _apiCaller = CreateClient();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
        }

        protected async Task CallApiAsync()
        {
            _result = await _apiCaller.GetAsync("/api/boards/1");
        }
    }
}
