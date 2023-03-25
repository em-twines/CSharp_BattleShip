using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBattleShip
{
    public class Submarine : Ship
    {
        public Submarine(string name) : base(name)
        {
            health = 3;
            size = 3;
        }
    }
}
