using BattleshipChallenge.Core.Exceptions;
using BattleshipChallenge.Core.Models;
using BattleshipChallenge.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipChallenge.Core.Services
{
    public interface IBoardService
    {
        Ship AddShipToBoard(Guid boardId, int playerId, Ship shipToAdd);

        Board SaveBoard(Board boardToCreate);
    }

    public class BoardService : IBoardService
    {
        private readonly InMemoryStore _inMemoryStore;

        public BoardService(InMemoryStore inMemoryStore)
        {
            _inMemoryStore = inMemoryStore;
        }

        public Ship AddShipToBoard(Guid boardId, int playerId, Ship shipToAdd)
        {
            Board boardToUpdate;
            try
            {
                // always expect for the board/player to be created before the game begins
                boardToUpdate = _inMemoryStore.Boards.First(board => board.Id == boardId);
            }
            catch (Exception ex)
            {
                throw new NotFoundException($"no board found with the requested Id");
            }

            shipToAdd.OccupiedCoordinates = boardToUpdate.GetShipCoordinates(shipToAdd.Size);

            // check if player exists
            PlayerShips playerShips = boardToUpdate.PlayerShips?.FirstOrDefault(o => o.PlayerId == playerId);

            // if player exists add ship to the board
            if (playerShips != null)
            {
                shipToAdd.Id = Guid.NewGuid();
                playerShips.Ships.Add(shipToAdd);
            }
            else
            {
                boardToUpdate.PlayerShips ??= new List<PlayerShips>();
                // create a new playerShips and add to the board
                var newPlayerShips = new PlayerShips()
                {
                    PlayerId = playerId,
                    Ships = new List<Ship>()
                };

                shipToAdd.Id = Guid.NewGuid();
                newPlayerShips.Ships.Add(shipToAdd);
                boardToUpdate.PlayerShips.Add(newPlayerShips);
            }

            return shipToAdd;
        }

        public Board SaveBoard(Board boardToCreate)
        {
            boardToCreate.Id = Guid.NewGuid();
            _inMemoryStore.Boards.Add(boardToCreate);
            return boardToCreate;
        }
    }
}