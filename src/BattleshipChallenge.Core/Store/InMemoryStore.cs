using BattleshipChallenge.Core.Models;
using System.Collections.Generic;

namespace BattleshipChallenge.Core.Store
{
    public class InMemoryStore
    {
        public InMemoryStore()
        {
            Boards = new List<Board>();
            Players = new List<Player>();
        }

        public List<Board> Boards { get; set; }
        public List<Player> Players { get; set; }
    }
}