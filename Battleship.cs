using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBattleShip
{
    public class Battleship : Ship
    {

        public Battleship(string name) : base(name)
        {
            health = 4;
            size = 4; 
        }
    }
}
