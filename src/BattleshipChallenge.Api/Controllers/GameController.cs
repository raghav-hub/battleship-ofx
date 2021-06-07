using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipChallenge.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipChallenge.Api.Controllers
{
    [Route("api/boards/{boardId:int}/play")]
    public class GameController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post(int boardId, [FromBody] Coordinates attackCoordinates)
        {
            throw new NotImplementedException();
        }
    }
}
