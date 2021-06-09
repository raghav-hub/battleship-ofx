using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipChallenge.Core.Models
{
    public class Board
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<PlayerShips> PlayerShips { get; set; }
        public List<Coordinates> OccupiedCoordinates { get; set; }

        public IList<Coordinates> GetShipCoordinates(int shipSize)
        {
            OccupiedCoordinates ??= new List<Coordinates>();
            bool shipCoordinatesFound = false;
            var randomNumberGenerator = new Random();
            List<Coordinates> shipCoordinates = null;
            while (!shipCoordinatesFound)
            {
                // initially assign startColumn, endColumn as same
                // initially assign startRow, endRow as same
                int startColumn = randomNumberGenerator.Next(1, 11);
                int startRow = randomNumberGenerator.Next(1, 11);
                int endColumn = startColumn;
                int endRow = startRow;

                int alignment = randomNumberGenerator.Next(0, 1); // consider 0 for horizontal and 1 for vertical

                if (alignment == 0) // endRow to update as the alignment is horizontal
                {
                    endColumn = endColumn + (shipSize - 1);
                }
                else // endColumn to update as the alignment is vertical
                {
                    endRow = endRow + (shipSize - 1);
                }

                // if the coordinates fall out of the board, try again
                if (endColumn > 10 || endRow > 10)
                {
                    continue;
                }

                // group all the coordinates that will be allocated to the ship
                var expectedShipCoordinates = new List<Coordinates>();

                if (alignment == 0)
                {
                    // if horizontal
                    // e.g: shipSize is 2, startColumn 5, endColumn 6, startRow 9, startRow 9
                    // expectedShipCoordinates in (row, column): [{9, 5}, {9, 6}]
                    for (; endColumn >= startColumn; endColumn--)
                    {
                        expectedShipCoordinates.Add(new Coordinates(startRow, endColumn));
                    }
                }
                else
                {
                    // if vertical
                    // e.g: shipSize is 2, startColumn 5, endColumn 5, startRow 6, endRow 7
                    // expectedShipCoordinates in (row, column): [{6, 5}, {7, 5}]
                    for (; endRow >= startRow; endRow--)
                    {
                        expectedShipCoordinates.Add(new Coordinates(endRow, startColumn));
                    }
                }

                // check if the coordinates are already occupied
                bool areCoordinatesUsed = OccupiedCoordinates.Any(o => expectedShipCoordinates.Any(e => e.ColumnNumber == o.ColumnNumber && e.RowNumber == o.RowNumber));

                if (areCoordinatesUsed)
                {
                    continue;
                }

                // mark coordinates as found
                shipCoordinatesFound = true;
                shipCoordinates = expectedShipCoordinates;

                // add the coordinates to the board as occupied
                this.OccupiedCoordinates.AddRange(expectedShipCoordinates);
            }

            return shipCoordinates;
        }
    }
}