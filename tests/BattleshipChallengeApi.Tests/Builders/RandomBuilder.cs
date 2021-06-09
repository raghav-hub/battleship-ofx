using System;

namespace BattleshipChallengeApi.UnitTests
{
    public static class RandomBuilder
    {
        private static readonly Random Random = new Random();

        public static int NextNumber()
        {
            lock (Random)
            {
                return Random.Next();
            }
        }

        public static int NextNumber(int maxValue)
        {
            lock (Random)
            {
                return Random.Next(maxValue);
            }
        }

        public static string NextString()
        {
            return Guid.NewGuid().ToString();
        }

        public static Guid NextGuid()
        {
            return Guid.NewGuid();
        }
    }
}