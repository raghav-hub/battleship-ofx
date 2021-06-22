using System.Threading.Tasks;
using BattleshipChallenge.Core.Models;
using BattleshipChallengeApi.IntegrationTests.Builders;
using BattleshipChallengeApi.IntegrationTests.Fixtures;
using Xunit;

namespace BattleshipChallengeApi.Tests
{
    public class When_New_Board_Is_Created : AddNewBoardFixture
    {
        [Fact]
        public async Task Verify_Status_Of_NewBoard()
        {
            // arrange
            CreateSut();
            Board boardToCreate = new BoardBuilder().Build();

            // act
            await CallCreateBoardApiAsync(boardToCreate);

            // assert
            await AssertSuccessOnBoardCreation(boardToCreate);
        }
    }
}