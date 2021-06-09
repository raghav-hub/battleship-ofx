using System.Net.Http.Json;
using System.Threading.Tasks;
using BattleshipChallenge.Core.Models;
using BattleshipChallengeApi.IntegrationTests.Fixtures;
using BattleshipChallengeApi.UnitTests;
using FluentAssertions;
using Xunit;

namespace BattleshipChallengeApi.Tests
{
    public class When_Game_Progresses : GameInProgressFixture
    {
        [Fact]
        public async Task Add_Ship_To_Board()
        {
            // arrange
            CreateSut();
            var expectedShip = new Ship
            {
                Name = RandomBuilder.NextString(),
                Size = RandomBuilder.NextNumber(9)
            };

            // act
            var addShipResponse = (await CallAddShipToBoardApiAsync(expectedShip)).Content.ReadFromJsonAsync<Ship>().Result;

            // assert
            expectedShip.Id = FetchShipId(_addToShipBoardId, _addToShipPlayerId, expectedShip.Name);

            // to be enabled after the 'OccupiedCoordinates', 'HitCoordinates' are ignored using JsonIgnore attribute(post code review)
            //addShipResponse.Should().BeEquivalentTo(expectedShip);
        }

        [Fact]
        public async Task Player_Makes_A_Successful_Attack()
        {
            // arrange
            CreateSut();
            var expectedAttackReponse = new AttackResponse()
            {
                IsHit = true, IsSunk = false
            };

            // act
            var attackResponse = (await CallAttackShipOnBoardApiAsync()).Content.ReadFromJsonAsync<AttackResponse>().Result;

            // assert
            attackResponse.Should().BeEquivalentTo(expectedAttackReponse);
        }

        [Fact]
        public async Task Player_Makes_Two_Attacks_On_Same_Coordinates()
        {
            // arrange
            CreateSut();
            var expectedAttackOneResponse = new AttackResponse
            {
                IsHit = true,
                IsSunk = false
            };

            var expectedAttackTwoResponse = new AttackResponse
            {
                IsHit = false,
                IsSunk = false
            };

            // act
            var attackOneResponse = (await CallAttackShipOnBoardApiAsync()).Content.ReadFromJsonAsync<AttackResponse>().Result;
            var attackTwoResponse = (await CallAttackShipOnBoardApiAsync()).Content.ReadFromJsonAsync<AttackResponse>().Result;

            // assert
            attackOneResponse.Should().BeEquivalentTo(expectedAttackOneResponse);
            attackTwoResponse.Should().BeEquivalentTo(expectedAttackTwoResponse);
        }
    }
}