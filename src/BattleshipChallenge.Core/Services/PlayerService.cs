using System;
using BattleshipChallenge.Core.Models;
using BattleshipChallenge.Core.Store;
using System.Linq;

namespace BattleshipChallenge.Core.Services
{
    public interface IPlayerService
    {
        Player SavePlayer(Player playerToAdd);
    }

    public class PlayerService : IPlayerService
    {
        private readonly InMemoryStore _inMemoryStore;

        public PlayerService(InMemoryStore inMemoryStore)
        {
            _inMemoryStore = inMemoryStore;
        }

        public Player SavePlayer(Player playerToCreate)
        {
            playerToCreate.Id = Guid.NewGuid();
            _inMemoryStore.Players.Add(playerToCreate);
            return playerToCreate;
        }
    }
}