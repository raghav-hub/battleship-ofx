using System;
using System.ComponentModel.DataAnnotations;

namespace BattleshipChallenge.Core.Models
{
    public class Player
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}