using BattleshipChallenge.Core.Models;
using BattleshipChallenge.Core.Store;
using BattleshipChallengeApi.UnitTests;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BattleshipChallenge.Api.Infrastructure;
using BattleshipChallengeApi.Tests.Fixtures;
using Newtonsoft.Json;

namespace BattleshipChallengeApi.IntegrationTests.Fixtures
{
    public class AddNewBoardFixture : ControllerFixtureBase
    {
        protected HttpClient _apiCaller;
        protected HttpResponseMessage _result;
        private Guid _maxBoardIdInStore;

        public void CreateSut()
        {
            _apiCaller = CreateClient();
        }

        protected async Task CallGetApiAsync()
        {
            _result = await _apiCaller.GetAsync("/api/boards/1");
        }

        protected async Task CallCreateBoardApiAsync(Board boardToCreate = null)
        {
            _result = await _apiCaller.PostAsJsonAsync("/api/boards", boardToCreate);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            InMemoryStore testState = new InMemoryStore();
            _maxBoardIdInStore = RandomBuilder.NextGuid();

            testState.Boards.Add(new Board()
            {
                // assuming there are already existing boards in the store
                Id = _maxBoardIdInStore,
                Name = RandomBuilder.NextString()
            });
            base.ConfigureWebHost(builder);

            var testStateAsOptions = Options.Create(testState);

            // inject custom test store into the service collection
            builder.ConfigureTestServices(services =>
                services.Replace(ServiceDescriptor.Transient(provider => testStateAsOptions)));
        }

        protected async Task AssertSuccessOnBoardCreation(Board expectedBoard)
        {
            var apiResponse = await _result.Content.ReadFromJsonAsync<ApiSuccessResponse>();
            var apiCreatedBoard = JsonConvert.DeserializeObject<Board>(apiResponse.Data.ToString());
            apiCreatedBoard.Name.Should().Be(expectedBoard.Name);
            apiCreatedBoard.PlayerShips.Should().BeNull();
            apiCreatedBoard.OccupiedCoordinates.Should().BeNull();
        }
    }
}