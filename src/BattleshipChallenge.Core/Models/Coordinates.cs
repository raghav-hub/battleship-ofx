using System;
using System.ComponentModel.DataAnnotations;

namespace BattleshipChallenge.Core.Models
{
    public class Coordinates
    {
        public Coordinates()
        {
        }

        public Coordinates(int rowNumber, int columnNumber)
        {
            ColumnNumber = columnNumber;
            RowNumber = rowNumber;
        }

        [Required]
        public int RowNumber { get; set; }

        [Required]
        public int ColumnNumber { get; set; }

        // override equals to match on rowNo, colNo (no reference check needed)
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            var coordinates = (Coordinates)obj;
            return coordinates.ColumnNumber == ColumnNumber && coordinates.RowNumber == RowNumber;
        }
    }
}