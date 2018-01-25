using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class TrapRoom : Room
    {
        int type;
        string name;
        public bool disarmed, triggered;
        Random random = new Random();

        public TrapRoom(int x, int y)
        {
            this.xLoc = x;
            this.yLoc = y;
            SetTrap();
            description = "This part of the Dungeon \nseems eerily quiet.";
            disarmed = false;
            triggered = false;
        }

        void SetTrap()
        {
            type = random.Next(1, 7);
            switch (type)
            {
                case 1:
                    name = "Poison Darts.";


                    break;
                case 2:
                    name = "Pit of Spikes.";

                    break;
                case 3:
                    name = "Bladed Pendulum.";

                    break;
                case 4:
                    name = "Falling Rocks.";

                    break;
                case 5:
                    name = "Poison Gas";

                    break;
                case 6:
                    name = "";

                    break;
            }
        }


    }
}
