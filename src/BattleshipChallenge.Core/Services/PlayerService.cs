using System;
using System.Collections.Generic;
using System.Text;
using BattleshipChallenge.Core.Models;

namespace BattleshipChallenge.Core.Services
{
    public interface IPlayerService
    {
        Player SavePlayer(Player playerToAdd);
        void AddPlayerToBoard(int boardId, int playerId);
    }
    public class PlayerService : IPlayerService
    {
        public Player SavePlayer(Player playerToCreate)
        {
            throw new NotImplementedException();
        }

        public void AddPlayerToBoard(int boardId, int playerId)
        {
            throw new NotImplementedException();
        }
    }
}
