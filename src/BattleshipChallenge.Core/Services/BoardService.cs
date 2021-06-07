using System;
using System.Collections.Generic;
using System.Text;
using BattleshipChallenge.Core.Models;

namespace BattleshipChallenge.Core.Services
{
    public interface IBoardService
    {
        Board SaveBoard(Board boardToCreate);
    }
    public class BoardService : IBoardService
    {
        public Board SaveBoard(Board boardToCreate)
        {
            throw new NotImplementedException();
        }
    }
}
