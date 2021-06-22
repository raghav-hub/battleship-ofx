using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace BattleshipChallenge.Api.Infrastructure
{
    public class ApiResponse
    {
        public object Meta =>
            new
            {
                apiName = "battleship api",
                apiVersion = "1.0.0",
                author = "raghav p"
            };
    }
}