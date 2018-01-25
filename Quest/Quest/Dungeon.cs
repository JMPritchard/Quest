using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class Dungeon
    {

        public int currentLevel;
        public bool getFocus;

        Texture2D unknown, empty, encounter, trap, stair, gate, player, treasure, backfill;
        Vector2 position, textPosition;
        SpriteFont font;
        Rectangle infoRec;

        List<Level> levellist = new List<Level>();

        //dungeon tile start locations
        const int POSX = 370;
        const int POSY = 15;


        public Dungeon()
        {
            //levellist index
            currentLevel = 0;
            Level level1 = new Level();
            Level level2 = new Level();
            Level level3 = new Level();
            levellist.Add(level1);
            levellist.Add(level2);
            levellist.Add(level3);

            getFocus = false;

            textPosition = new Vector2(930, 25);
            infoRec = new Rectangle(920, 15, 350, 655);
        }

        public void LoadContent(ContentManager content)
        {
            player = content.Load<Texture2D>("playertile");
            empty = content.Load<Texture2D>("tile");
            unknown = content.Load<Texture2D>("unknownroom");
            encounter = content.Load<Texture2D>("encounter");
            stair = content.Load<Texture2D>("stair");
            trap = content.Load<Texture2D>("trap");
            gate = content.Load<Texture2D>("gate");
            treasure = content.Load<Texture2D>("treasure");
            backfill = content.Load<Texture2D>("backfill");
            font = content.Load<SpriteFont>("smallFont");

        }

        public void Update(GameTime gametime, int y, int x)
        {
            //determine roomList index location for character
            int charRoom = (x * 7 + y);

            //resolve any active events in the current Room
                //locked gate
            if (levellist[currentLevel].roomType[x, y] == 2)
            {

            }
                //encounter
            else if (levellist[currentLevel].roomType[x, y] == 3 )
            {

            }
                //trap
            else if (levellist[currentLevel].roomType[x, y] == 4)
            {
                
                //ResolveTrap(charRoom);
            }
                //stairway
            else if (levellist[currentLevel].roomType[x, y] == 5)
            {

            }
                //treasure
            else if (levellist[currentLevel].roomType[x, y] == 6)
            {

            }

            if (!levellist[currentLevel].roomList[charRoom].revealed)
            {
                //set visit status
                levellist[currentLevel].roomList[charRoom].revealed = true;
                //focus element for new exploration
                getFocus = true;
                //change room type if required
                if(levellist[currentLevel].roomType[x, y] != 1)
                {
                    //levellist[currentLevel].roomType[x, y] = 1;
                    //levellist[currentLevel].roomList[charRoom] = new EmptyRoom(x, y, 1);
                }

            }


            //levellist[currentLevel].roomType[x, y] = 1;

        }

        void ResolveTrap(int charRoom)
        {

        }

        public void Draw(SpriteBatch spritebatch, int x, int y)
        {
            int posX, posY;
            posX = POSX;
            posY = POSY;

            //draw dungeon map
            for (int i = 0; i < 7; i ++)
            {
                for (int j = 0; j < 7; j ++)
                {
                    position = new Vector2(posX, posY);

                    int roomIndex = (i * 7 + j);
                    //if this room has not been revealed, display unknown room icon
                    if (!levellist[currentLevel].roomList[roomIndex].revealed)
                    {
                        spritebatch.Draw(unknown, position, Color.White);
                    }
                    //otherwise display the icon corresponding to the room type
                    else
                    {
                        if (levellist[currentLevel].roomType[i, j] == 1) spritebatch.Draw(empty, position, Color.White);
                        else if (levellist[currentLevel].roomType[i, j] == 2) spritebatch.Draw(gate, position, Color.White);
                        else if (levellist[currentLevel].roomType[i, j] == 3) spritebatch.Draw(encounter, position, Color.White);
                        else if (levellist[currentLevel].roomType[i, j] == 4) spritebatch.Draw(trap, position, Color.White);
                        else if (levellist[currentLevel].roomType[i, j] == 5) spritebatch.Draw(treasure, position, Color.White);
                        else if (levellist[currentLevel].roomType[i, j] == 6) spritebatch.Draw(stair, position, Color.White);
                    }

                    //if coordinates match the character position, draw the character icon
                    if (x == j && y == i)
                    {
                        spritebatch.Draw(player, position, Color.White);
                    }
                    //move draw position to the right after tile has been drawn
                    posX += 75;
                }
                //move draw position down a row after a complete row of tiles has been drawn
                posX = POSX;
                posY += 75;
            }

            //draw dungeon information box
            spritebatch.Draw(backfill, infoRec, Color.LightGray);
            //info box content
            int currentRoom = (x*7 + y);
            spritebatch.DrawString(font, "Dungeon Level: " + (currentLevel+1).ToString() + "\n\n" + 
                levellist[currentLevel].roomList[currentRoom].description, textPosition, Color.Black);


        }




    }
}
