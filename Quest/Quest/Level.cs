using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class Level
    {

        //values in roomType indicate concrete room classes: 0 = empty,
        public int[,] roomType;

        //dungeon level constants
        const int TILESWIDE = 7;
        const int TILESHIGH = 7;

        Random random = new Random();

        //This list is a collection of all concrete Room objects
        public List<Room> roomList = new List<Room>();

        public Level()
        {
            roomType = new int[TILESWIDE, TILESHIGH];
            PopulateArray();
        }

        public void Update(GameTime gametime)
        {

        }

        public void PopulateArray()
        {

            for (int i = 0; i < TILESHIGH; i++)
            {
                for (int j = 0; j < TILESWIDE; j++)
                {
                    //1 = empty, 2 = locked, 3 = encounter, 4 = trap, 5 = treasure, 6 = stairway
                    int randRoom = random.Next(1, 7);
                    if (randRoom == 6) randRoom = 3;
                    roomType[j, i] = randRoom;
                    //switch to add Room objects to roomList based on roomType
                    switch (roomType[j,i])
                    {
                        case 1:
                            roomList.Add(new EmptyRoom(j, i));
                            break;
                        case 2:
                            roomList.Add(new LockedRoom(j, i));
                            break;
                        case 3:
                            roomList.Add(new EncounterRoom(j,i));
                            break;
                        case 4:
                            roomList.Add(new TrapRoom(j, i));
                            break;
                        case 5:
                            roomList.Add(new TreasureRoom(j, i));
                            break;
                    }

                }
            }
            //create a single stairway room within first two rows
            int randX = random.Next(0, 7);
            int randY = random.Next(0, 2);
            int roomIndex = (randX * 7 + randY);
            roomType[randY, randX] = 6;
            roomList[roomIndex] = new StairwayRoom(randY, randX);

            //create a single "special" room somewhere not on the staircase or starting room

            //level starting room is always empty
            roomType[6, 3] = 1;
            roomList[27] = new EmptyRoom(6,3);
        }


    }
}
