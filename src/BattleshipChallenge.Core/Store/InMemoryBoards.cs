using System.Collections.Generic;
using BattleshipChallenge.Core.Models;

namespace BattleshipChallenge.Core.Store
{
    public class InMemoryBoards
    {
        public IList<Board> Boards { get; set; }
    }
}
