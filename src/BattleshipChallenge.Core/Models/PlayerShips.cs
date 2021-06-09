using System.Collections.Generic;

namespace BattleshipChallenge.Core.Models
{
    public class PlayerShips
    {
        public int PlayerId { get; set; }
        public IList<Ship> Ships { get; set; }
    }
}