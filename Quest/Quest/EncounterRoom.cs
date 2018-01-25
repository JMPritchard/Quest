using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class EncounterRoom : Room
    {

        public EncounterRoom(int x, int y)
        {
            this.xLoc = x;
            this.yLoc = y;
            description = "You encounter a monster!!";
        }

    }
}
