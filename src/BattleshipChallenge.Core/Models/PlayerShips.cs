using System;
using System.Collections.Generic;

namespace BattleshipChallenge.Core.Models
{
    public class PlayerShips
    {
        public Guid PlayerId { get; set; }
        public IList<Ship> Ships { get; set; }
    }
}