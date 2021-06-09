using BattleshipChallenge.Core.Models;
using BattleshipChallengeApi.IntegrationTests.ShipCoordinateAllocationTests.TheoryData;
using BattleshipChallengeApi.UnitTests.TheoryData;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BattleshipChallengeApi.IntegrationTests.ShipCoordinateAllocationTests
{
    public class When_NewShip_Added
    {
        [Theory]
        [ClassData(typeof(AddNewShipTheories))]
        public void Verify_Coordinates_OnTheBoard(string description, AddNewShipTheoryData theory)
        {
            Board boardInAction = theory.Board;

            // act
            IList<Coordinates> actualCoordinates = boardInAction.GetShipCoordinates(theory.NewShipSize);

            // assert
            Assert.True(actualCoordinates.All(theory.ExpectedCoordinates.Contains));
            Assert.True(actualCoordinates.Count == theory.ExpectedCoordinates.Count);
        }
    }
}