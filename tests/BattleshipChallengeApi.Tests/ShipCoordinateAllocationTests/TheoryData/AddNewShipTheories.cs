using BattleshipChallenge.Core.Models;
using BattleshipChallengeApi.UnitTests;
using BattleshipChallengeApi.UnitTests.TheoryData;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BattleshipChallengeApi.IntegrationTests.ShipCoordinateAllocationTests.TheoryData
{
    public class AddNewShipTheories : TheoryData<string, AddNewShipTheoryData>
    {
        private static IList<Coordinates> _boardCoordinates;

        public AddNewShipTheories()
        {
            _boardCoordinates = BoardCoordinates();
            AddNewShip_Size9_VerticalAlignment_Row2To10_Column1();
            AddNewShip_Size9_HorizontalAlignment_Row1_Column2to10();
        }

        private List<Coordinates> BoardCoordinates()
        {
            List<Coordinates> boardCoordinates = new List<Coordinates>();

            for (var row = 1; row < 11; row++)
            {
                for (var column = 1; column < 11; column++)
                {
                    boardCoordinates.Add(new Coordinates(column, row));
                }
            }

            return boardCoordinates;
        }

        private void AddNewShip_Size9_VerticalAlignment_Row2To10_Column1()
        {
            List<Coordinates> occupiedCoordinates = new List<Coordinates>();

            // occupy all the columns except for column 1
            for (int row = 1; row < 11; row++)
            {
                for (int column = 2; column < 11; column++)
                {
                    occupiedCoordinates.Add(new Coordinates(column, row));
                }
            }

            // occupy the first R1C1
            occupiedCoordinates.Add(new Coordinates(1, 1));

            var boardInAction = new Board()
            {
                Id = RandomBuilder.NextGuid(),
                Name = RandomBuilder.NextString(),
                OccupiedCoordinates = occupiedCoordinates,
                PlayerShips = new List<PlayerShips>()
            };

            boardInAction.PlayerShips.Add(new PlayerShips()
            {
                PlayerId = RandomBuilder.NextGuid()
            });

            // expected new ship coordinates
            IList<Coordinates> expectedShipCoordinates = _boardCoordinates.Except(occupiedCoordinates, new CoordinatesComparer()).ToList();

            Add(nameof(AddNewShip_Size9_VerticalAlignment_Row2To10_Column1), new AddNewShipTheoryData()
            {
                Board = boardInAction,
                ExpectedCoordinates = expectedShipCoordinates,
                NewShipSize = 9
            });
        }

        private void AddNewShip_Size9_HorizontalAlignment_Row1_Column2to10()
        {
            List<Coordinates> occupiedCoordinates = new List<Coordinates>();

            // occupy all the rows except for row 1
            for (int row = 2; row < 11; row++)
            {
                for (int column = 1; column < 11; column++)
                {
                    occupiedCoordinates.Add(new Coordinates(row, column));
                }
            }

            // occupy the first R1C1
            occupiedCoordinates.Add(new Coordinates(1, 1));

            var boardInAction = new Board()
            {
                Id = RandomBuilder.NextGuid(),
                Name = RandomBuilder.NextString(),
                OccupiedCoordinates = occupiedCoordinates,
                PlayerShips = new List<PlayerShips>()
            };

            boardInAction.PlayerShips.Add(new PlayerShips()
            {
                PlayerId = RandomBuilder.NextGuid()
            });

            // expected new ship coordinates
            IList<Coordinates> expectedShipCoordinates = _boardCoordinates.Except(occupiedCoordinates, new CoordinatesComparer()).ToList();

            Add(nameof(AddNewShip_Size9_HorizontalAlignment_Row1_Column2to10), new AddNewShipTheoryData()
            {
                Board = boardInAction,
                ExpectedCoordinates = expectedShipCoordinates,
                NewShipSize = 9
            });
        }
    }
}