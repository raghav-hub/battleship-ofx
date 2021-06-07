using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipChallenge.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipChallenge.Api.Controllers
{
    [Route("api/boards/{boardId:int}/[controller]")]
    public class ShipsController : ControllerBase
    {
        [HttpGet("{shipId}")]
        public ActionResult Get(int boardId, int shipId)
        {
            throw new NotImplementedException("in progress");
        }

        [HttpPost]
        public ActionResult Post(int boardId, [FromBody] Ship ship)
        {
            throw new NotImplementedException("in progress");
        }
    }
}
