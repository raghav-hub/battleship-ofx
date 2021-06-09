using BattleshipChallenge.Core.Models;
using System.Collections.Generic;

namespace BattleshipChallengeApi.UnitTests.TheoryData
{
    public class AddNewShipTheoryData
    {
        public Board Board { get; set; }

        public int NewShipSize { get; set; }
        public IList<Coordinates> ExpectedCoordinates { get; set; }
    }
}