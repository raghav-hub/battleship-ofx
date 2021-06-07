using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipChallenge.Core.Enums
{
    public enum ShipType
    {
        //rules ref: https://www.thesprucecrafts.com/the-basic-rules-of-battleship-411069
        Carrier, // occupies 5 holes
        Battleship, // occupied 4 holes
        Cruiser,// occupied 3 holes
        Submarine,// occupied 3 holes
        Destroyer// occupied 2 holes
    }
}
