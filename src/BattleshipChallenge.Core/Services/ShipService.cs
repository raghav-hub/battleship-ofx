using System;
using System.Collections.Generic;
using System.Text;
using BattleshipChallenge.Core.Models;

namespace BattleshipChallenge.Core.Services
{
    public interface IShipService
    {
        Ship SaveShip(Ship shipToCreate);
    }
    public class ShipService : IShipService
    {
        public Ship SaveShip(Ship shipToCreate)
        {
            throw new NotImplementedException();
        }
    }
}
