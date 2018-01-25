using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class TreasureRoom : Room
    {

        public TreasureRoom(int x, int y)
        {
            this.xLoc = x;
            this.yLoc = y;
            description = "This room contains TREASURE!";
        }

    }
}
