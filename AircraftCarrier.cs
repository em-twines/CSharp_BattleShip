using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBattleShip
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(string name) : base(name)
        {
            health = 5;
            size = 5;
        }
    }
}
