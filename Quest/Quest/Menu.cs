using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class Menu
    {
        Texture2D title, menu, icon;
        Vector2 titlePos, menuPos;

        //gamestate variable: 0 = transition, 1 = returningtomenu, 2 = menu, 3 = start new game, 4 = load, 5 = save, 6 = exit;
        public int gamestate;
        int menuTimer;
        int iconX, iconY;

        bool showtitle, gamestarted;

        //icon home positions
        const int STARTX = 390;
        const int MENUWIDTH = 494;
        const int STARTY = 136;
        const int LOADY = 241;
        const int SAVEY = 346;
        const int EXITY = 451;

        //user input variables
        Keys[] currentKeys;
        Keys[] oldKeys;

        public Menu()
        {
            titlePos = new Vector2(440,277);
            menuPos = new Vector2(300, 134);
            iconX = STARTX;
            iconY = STARTY;

            gamestate = 0;
            menuTimer = 0;

            showtitle = false;
            gamestarted = false;
        }

        public void LoadContent(ContentManager content)
        {
            //textures
            title = content.Load<Texture2D>("questtitle");
            menu = content.Load<Texture2D>("menu");
            icon = content.Load<Texture2D>("swordicon");

        }


        public void Update(GameTime gametime)
        {
            //show title if game has just started, then fade title away after a few seconds
            if (gamestate == 0) menuTimer++;
            //timer @ 200 and 550
            if (menuTimer > 100 && menuTimer < 200) showtitle = true;
            else if (menuTimer > 200 && showtitle)
            {
                showtitle = false;
                gamestate = 2;
            }

            //if returning to menu from another screen
            if (gamestate == 1)
            {
                //reset icon position
                iconX = STARTX;
                iconY = STARTY;
                //set to menu gamestate
                gamestate = 2;
            }
            //if in menu state, collect user inputs
            else if (gamestate == 2)
            {
                KeyboardState keystate = Keyboard.GetState();
                //collect user keypresses
                currentKeys = keystate.GetPressedKeys();

                if (oldKeys != null)
                {
                    bool match = false;
                    //check all currentkeys and oldkeys for discrepancy
                    for (int i = 0; i < currentKeys.Length; i++)
                    {
                        for (int j = 0; j < oldKeys.Length; j++)
                        {
                            if (oldKeys[j] == currentKeys[i]) match = true;
                        }
                        //if discrepancy is found
                        if (!match)
                        {
                            if (iconY == STARTY)
                            {
                                //move icons by W/S or UP/DOWN, ENTER to select
                                if (currentKeys[i] == Keys.Down || currentKeys[i] == Keys.S)
                                {
                                    iconY = LOADY;
                                }
                                if (currentKeys[i] == Keys.Up || currentKeys[i] == Keys.W)
                                {
                                    iconY = EXITY;
                                }
                                if (currentKeys[i] == Keys.Enter)
                                {
                                    gamestate = 3;
                                }
                            }
                            else if (iconY == LOADY)
                            {
                                //move icons by W/S or UP/DOWN, ENTER to select
                                if (currentKeys[i] == Keys.Down || currentKeys[i] == Keys.S)
                                {
                                    iconY = SAVEY;
                                }
                                if (currentKeys[i] == Keys.Up || currentKeys[i] == Keys.W)
                                {
                                    iconY = STARTY;
                                }
                                if (currentKeys[i] == Keys.Enter)
                                {
                                    gamestate = 4;
                                }
                            }
                            else if (iconY == SAVEY)
                            {
                                //move icons by W/S or UP/DOWN, ENTER to select
                                if (currentKeys[i] == Keys.Down || currentKeys[i] == Keys.S)
                                {
                                    iconY = EXITY;
                                }
                                if (currentKeys[i] == Keys.Up || currentKeys[i] == Keys.W)
                                {
                                    iconY = LOADY;
                                }
                                if (currentKeys[i] == Keys.Enter)
                                {
                                    gamestate = 5;
                                }
                            }
                            else if (iconY == EXITY)
                            {
                                //move icons by W/S or UP/DOWN, ENTER to select
                                if (currentKeys[i] == Keys.Down || currentKeys[i] == Keys.S)
                                {
                                    iconY = STARTY;
                                }
                                if (currentKeys[i] == Keys.Up || currentKeys[i] == Keys.W)
                                {
                                    iconY = SAVEY;
                                }
                                if (currentKeys[i] == Keys.Enter)
                                {
                                    gamestate = 6;
                                }
                            }

                        }
                    }
                }
                oldKeys = currentKeys;

            }
            else if (gamestate == 4)
            {

                ReturnToMenu();

            }
            else if (gamestate == 5)
            {

                ReturnToMenu();

            }


        }

        public void Draw(SpriteBatch spritebatch)
        {

            if (showtitle) spritebatch.Draw(title, titlePos, Color.White);
            //state machine indexes for menu, load, and save screens
            if (gamestate == 2)
            {
                Vector2 iconPos = new Vector2(iconX, iconY);
                spritebatch.Draw(menu, menuPos, Color.White);
                spritebatch.Draw(icon, iconPos, Color.White);
                iconPos = new Vector2(iconX + MENUWIDTH, iconY);
                spritebatch.Draw(icon, iconPos, Color.White);
            }
            else if (gamestate == 4)
            {
                //load
            }
            else if (gamestate == 5)
            {
                //save
            }

        }

        private void ReturnToMenu()
        {

            gamestate = 1;

        }

    }
}
