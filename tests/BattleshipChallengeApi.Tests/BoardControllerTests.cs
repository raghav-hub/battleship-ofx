using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using Newtonsoft.Json;

using BattleshipChallengeApi;
using BattleshipChallengeApi.Tests.Fixtures;


namespace BattleshipChallengeApi.Tests
{
    public class BoardControllerTests : BoardsControllerFixture    
    {
        [Fact]
        public async Task TestGet()
        {
            // arrange
            CreateSut();

            // act
            await CallApiAsync();

            // assert
            Assert.Equal(200, (int)_result.StatusCode);
            Assert.Equal("this is for test purposes", _result.Content.ReadAsStringAsync().Result);
        }
    }
}
