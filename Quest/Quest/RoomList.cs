using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    public class RoomList
    {
        //THIS CLASS IS DEAD

        //values in roomArray indicate room types: 0 = empty,
        public int[,] roomArray;

        const int TILESWIDE = 7;
        const int TILESHIGH = 7;

        Random random = new Random();

        public RoomList()
        {
            roomArray = new int[TILESWIDE, TILESHIGH];
            PopulateArray();
        }

        public void PopulateArray()
        {
            for(int i=0; i < TILESHIGH; i++)
            {
                for(int j=0; j < TILESWIDE; j++)
                {
                    //1 = empty, 2 = gate, 3 = unknown, 4 = encounter, 5 = trap, 6 = stair
                    int randRoom = random.Next(1, 7);
                    roomArray[j, i] = randRoom;
                }
            }
            //level starting room is always empty
            roomArray[6, 3] = 1;
        }

        public void Update(GameTime gametime)
        {

        }


    }
}
