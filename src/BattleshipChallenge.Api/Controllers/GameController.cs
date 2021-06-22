using BattleshipChallenge.Core.Models;
using BattleshipChallenge.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using BattleshipChallenge.Api.Infrastructure;

namespace BattleshipChallenge.Api.Controllers
{
    [Route("api/boards/{boardId}/play")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public ActionResult Post(Guid boardId, [FromBody] Coordinates attackedCoordinates)
        {
            AttackResponse response = _gameService.Attack(boardId, attackedCoordinates);
            return Ok(new ApiSuccessResponse(response));
        }
    }
}