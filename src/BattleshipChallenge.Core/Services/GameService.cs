using System;
using BattleshipChallenge.Core.Models;
using BattleshipChallenge.Core.Store;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipChallenge.Core.Services
{
    public interface IGameService
    {
        AttackResponse Attack(Guid boardId, Coordinates coordinates);
    }

    public class GameService : IGameService
    {
        private readonly InMemoryStore _inMemoryStore;

        public GameService(InMemoryStore inMemoryStore)
        {
            _inMemoryStore = inMemoryStore;
        }

        public AttackResponse Attack(Guid boardId, Coordinates coordinates)
        {
            Board boardInPlay = _inMemoryStore.Boards.First(o => o.Id == boardId);

            // for this exercise only using a single player limiting the game to the task requirements, hence PlayerShips.First() below
            Ship shipUnderAttack = boardInPlay.PlayerShips.First().Ships
                .FirstOrDefault(s => s.OccupiedCoordinates.Contains(coordinates));

            // check if a previous HIT position is attacked again
            if (shipUnderAttack != null && (shipUnderAttack.HitCoordinates == null || !shipUnderAttack.HitCoordinates.Contains(coordinates)))
            {
                shipUnderAttack.HitCoordinates ??= new List<Coordinates>();
                shipUnderAttack.HitCoordinates.Add(coordinates);

                return new AttackResponse()
                {
                    IsHit = true,
                    IsSunk = shipUnderAttack.Size == shipUnderAttack.HitCoordinates.Count
                };
            }

            return new AttackResponse();
        }
    }
}