using BattleshipChallenge.Core.Models;
using BattleshipChallenge.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using BattleshipChallenge.Api.Infrastructure;

namespace BattleshipChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("{boardId}")]
        public ActionResult Get(int boardId)
        {
            throw new NotImplementedException("not needed for this exercise");
        }

        [HttpPost]
        public ActionResult Post([FromBody] Board board)
        {
            Board newBoard = _boardService.SaveBoard(board);
            return Created(string.Empty, new ApiSuccessResponse(newBoard));
        }

        [HttpPut]
        public void Put([FromBody] Board board)
        {
            throw new NotImplementedException("not needed for this exercise");
        }

        [HttpDelete("{boardId}")]
        public void Delete(int boardId)
        {
            throw new NotImplementedException("not needed for this exercise");
        }
    }
}