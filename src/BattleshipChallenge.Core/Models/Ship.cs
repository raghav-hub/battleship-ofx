using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleshipChallenge.Core.Models
{
    public class Ship
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[JsonIgnore]
        //these props are opened just so that validating an attack becomes easier
        public IList<Coordinates> OccupiedCoordinates { get; set; }

        //[JsonIgnore]
        //these props are opened just so that validating an attack becomes easier
        public IList<Coordinates> HitCoordinates { get; set; }

        [Required]
        public int Size { get; set; }
    }
}