using BattleshipChallenge.Core.Models;
using BattleshipChallenge.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using BattleshipChallenge.Api.Infrastructure;

namespace BattleshipChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("{playerId}")]
        public ActionResult Get(int playerId)
        {
            throw new NotImplementedException("not needed for this exercise");
        }

        [HttpPost]
        public ActionResult Post([FromBody] Player player)
        {
            Player createdPlayer = _playerService.SavePlayer(player);
            return Ok(new ApiSuccessResponse(player));
        }

        [HttpPut]
        public void Put([FromBody] Player board)
        {
            throw new NotImplementedException("not needed for this exercise");
        }

        [HttpDelete("{playerId}")]
        public void Delete(int playerId)
        {
            throw new NotImplementedException("not needed for this exercise");
        }
    }
}