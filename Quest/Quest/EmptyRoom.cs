using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class EmptyRoom : Room
    {

        public EmptyRoom(int x, int y)
        {
            this.xLoc = x;
            this.yLoc = y;
            description = "This room is empty.";
        }

        public EmptyRoom(int x, int y, int z)
        {
            this.xLoc = x;
            this.yLoc = y;
            description = "This room is empty. There are\nsigns of recent fighting here.";
        }


    }
}
