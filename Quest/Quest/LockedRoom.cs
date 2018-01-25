using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class LockedRoom : Room
    {

        bool locked;

        public LockedRoom(int x, int y)
        {
            this.xLoc = x;
            this.yLoc = y;
            description = "This room is locked!";

            locked = true;
        }

    }
}
