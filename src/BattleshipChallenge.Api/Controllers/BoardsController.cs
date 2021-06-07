using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using BattleshipChallenge.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        [HttpGet("{boardId}")]
        public ActionResult Get(int boardId)
        {
            return Ok("this is for test purposes");
        }

        [HttpPost]
        public ActionResult Post([FromBody] Board board)
        {
            throw new NotImplementedException("in progress");
        }

        [HttpPut]
        public void Put([FromBody] Board board)
        {
            throw new NotImplementedException("not needed for exercise");
        }

        [HttpDelete("{id}")]
        public void Delete(int boardId)
        {
            // deletes the specific board
            throw new NotImplementedException("not needed for exercise");
        }
    }
}
