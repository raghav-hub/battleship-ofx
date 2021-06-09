using BattleshipChallenge.Core.Models;
using System.Collections.Generic;

namespace BattleshipChallengeApi.UnitTests.TheoryData
{
    public class CoordinatesComparer : IEqualityComparer<Coordinates>
    {
        public bool Equals(Coordinates x, Coordinates y)
        {
            if (x == null || y == null)
                return false;

            if (x.Equals(y))
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(Coordinates obj)
        {
            return base.GetHashCode();
        }
    }
}