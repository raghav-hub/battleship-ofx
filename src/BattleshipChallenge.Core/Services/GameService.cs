using System;
using System.Collections.Generic;
using System.Text;
using BattleshipChallenge.Core.Models;

namespace BattleshipChallenge.Core.Services
{
    public interface IGameService
    {
        AttackResponse Attack(int boardId, Coordinates coordinates);
    }
    public class GameService : IGameService
    {
        public AttackResponse Attack(int boardId, Coordinates coordinates)
        {
            throw new NotImplementedException();
        }
    }
}
