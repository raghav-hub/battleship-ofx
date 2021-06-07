using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using BattleshipChallenge.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipChallenge.Api.Controllers
{
    [Route("api/boards/{boardId:int}/[controller]")]
    public class PlayersController : ControllerBase
    {
        [HttpGet("{playerId}")]
        public ActionResult Get(int boardId, int playerId)
        {
            throw new NotImplementedException("in progress");
        }

        [HttpPost]
        public ActionResult Post(int boardId, [FromBody] Player player)
        {
            throw new NotImplementedException("in progress");
        }
    }
}
