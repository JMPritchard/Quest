using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class StairwayRoom : Room
    {
        public StairwayRoom(int x, int y)
        {
            this.xLoc = x;
            this.yLoc = y;
            description = "This room contains a long, \nstone stairway that extends" +
                "\nforbodingly into the earth.";
        }
    }
}
