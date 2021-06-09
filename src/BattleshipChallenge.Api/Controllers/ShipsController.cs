using BattleshipChallenge.Core.Models;
using BattleshipChallenge.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BattleshipChallenge.Api.Controllers
{
    [Route("api/boards/{boardId}/players/{playerId}/[controller]")]
    public class ShipsController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public ShipsController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("{shipId}")]
        public ActionResult Get(int shipId)
        {
            throw new NotImplementedException("not needed for the exercise");
        }

        [HttpPost]
        public ActionResult Post(Guid boardId, int playerId, [FromBody] Ship ship)
        {
            Ship shipAdded = _boardService.AddShipToBoard(boardId, playerId, ship);
            return Ok(shipAdded);
        }
    }
}