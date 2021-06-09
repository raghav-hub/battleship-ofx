using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BattleshipChallenge.Core.Models;
using BattleshipChallenge.Core.Store;
using BattleshipChallengeApi.IntegrationTests.Fixtures;
using BattleshipChallengeApi.UnitTests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace BattleshipChallengeApi.Tests.Fixtures
{
    public class GameInProgressFixture : ControllerFixtureBase
    {
        protected HttpClient _apiCaller;
        protected InMemoryStore _testState;

        #region AddToShip data

        protected Guid _addToShipBoardId;
        protected int _addToShipPlayerId;
        #endregion

        #region AttackShip data

        private Guid _attckShipBoardId;
        private int _attackShipPlayerId;
        private int _attackedRowCoordinate;
        private int _attackedColumnCoordinate;
        #endregion

        public void CreateSut()
        {
            _apiCaller = CreateClient();
            
        }

        protected async Task<HttpResponseMessage> CallAddShipToBoardApiAsync(Ship shipToCreate)
        {
            return await _apiCaller.PostAsJsonAsync($"/api/boards/{_addToShipBoardId}/players/{_addToShipPlayerId}/ships", shipToCreate);
        }

        protected async Task<HttpResponseMessage> CallAttackShipOnBoardApiAsync()
        {
            return await _apiCaller.PostAsJsonAsync($"/api/boards/{_attckShipBoardId}/play", new Coordinates(_attackedRowCoordinate, _attackedColumnCoordinate));
        }

        protected Guid FetchShipId(Guid boardId, int playerId, string name)
        {
            return _testState.Boards.FirstOrDefault(b => b.Id == boardId)
                    .PlayerShips.FirstOrDefault(p => p.PlayerId == playerId)
                    .Ships.FirstOrDefault(s => s.Name == name).Id;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            _addToShipBoardId = RandomBuilder.NextGuid();
            _addToShipPlayerId = RandomBuilder.NextNumber();
            _attckShipBoardId = RandomBuilder.NextGuid();
            _attackShipPlayerId = RandomBuilder.NextNumber();
            _attackedRowCoordinate = RandomBuilder.NextNumber(11);
            _attackedColumnCoordinate = RandomBuilder.NextNumber(11);

            #region populate test data into store

            _testState = new InMemoryStore();
            // setup board for adding a ship to the board
            _testState.Boards.Add(new Board
            {
                Id = _addToShipBoardId,
                Name = RandomBuilder.NextString(),
            });

            // setup board for an attack move
            var shipOccupiedCoordinates = new List<Coordinates>
            {
                new Coordinates(_attackedRowCoordinate, _attackedColumnCoordinate),
                new Coordinates(_attackedRowCoordinate - 1, _attackedColumnCoordinate)
            };
            _testState.Boards.Add(new Board()
            {
                Id = _attckShipBoardId,
                Name = RandomBuilder.NextString(),
                OccupiedCoordinates = shipOccupiedCoordinates,
                PlayerShips = new List<PlayerShips>
                {
                    new PlayerShips
                    {
                        PlayerId = _attackShipPlayerId,
                        Ships = new List<Ship>
                        {
                            new Ship
                            {
                                Id = RandomBuilder.NextGuid(),
                                Name = RandomBuilder.NextString(),
                                Size = 2,
                                OccupiedCoordinates = shipOccupiedCoordinates
                            }
                        }
                    }
                }
            });
            #endregion

            base.ConfigureWebHost(builder);

            var testStateAsOptions = Options.Create(_testState);

            // inject custom test store into the service collection
            builder.ConfigureTestServices(services =>
                services.Replace(ServiceDescriptor.Transient(provider => testStateAsOptions)));
        }
    }
}