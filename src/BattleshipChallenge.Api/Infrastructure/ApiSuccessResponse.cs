using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipChallenge.Api.Infrastructure
{
    public class ApiSuccessResponse : ApiResponse
    {
        public Object Data { get; set; }

        public ApiSuccessResponse(object result)
        {
            Data = result;
        }

        public ApiSuccessResponse() { }
    }
}
