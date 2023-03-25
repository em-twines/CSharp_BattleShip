using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBattleShip
{
    public class Destroyer : Ship
    {
        public Destroyer(string name) : base(name)
        {
            health = 2;
            size = 2;
        }
    }
}
