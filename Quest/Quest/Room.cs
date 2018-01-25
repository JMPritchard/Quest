using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    abstract class Room
    {

        public int xLoc, yLoc;
        public string description;
        public bool revealed, resolved;

        public Room()
        {
            revealed = false;
            resolved = false;

        }


    }
}
