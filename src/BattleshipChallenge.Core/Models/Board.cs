using System.Collections.Generic;
using System.Reflection.Emit;
using BattleshipChallenge.Core.Enums;

namespace BattleshipChallenge.Core.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<PlayerShips> PlayerShips { get; set; }
    }
}
