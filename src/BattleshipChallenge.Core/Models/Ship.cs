using System;
using System.Collections.Generic;
using System.Text;
using BattleshipChallenge.Core.Enums;

namespace BattleshipChallenge.Core.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ShipType Type { get; set; }
        public IList<Coordinates> OccupiedCoordinates { get; set; }
        public int Hits { get; set; }
        public int Size { get; set; }
    }
}
