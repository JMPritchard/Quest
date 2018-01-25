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
    class Character
    {
        Rectangle statRec, gearRec;
        Texture2D backfill;
        Vector2 statPos;
        SpriteFont font;

        //status
        public bool completeChar, inDungeon, backToMenu;
        //main statistics
        public string name;
        public int strength, agility, magic;
        //derived statistics
        public int maxHP, currentHP, maxMana, currentMana;
        public int combat, stealth, focus;
        //equipment indexes
        public int weapon, armour, gear1, gear2, motive, gold;

        //state machine for character creation: 1 = need stats, 2 = need spells, 3 = need equipment, 4 = need name, 5 = need motivation, 6 = done
        int charstate;
        //map info
        public int charX, charY;

        //character creation constants
        const int MAXTOTAL = 10;
        const int MINSTAT = 1;
        const int MAXSTAT = 7;
        const int FOCUSLIMIT = 3;

        //character objects
        WeaponList weaponlist = new WeaponList();
        ArmourList armourlist = new ArmourList();
        GearList gearlist = new GearList();

        //keyboard input arrays
        Keys[] currentKeys;
        Keys[] oldKeys;


        public Character()
        {
            statRec = new Rectangle(25,15,320,450);
            gearRec = new Rectangle(25, 495, 320, 175);
            statPos = new Vector2(40,30);
            completeChar = false;
            inDungeon = false;
            backToMenu = false;
            focus = 0;
            charstate = 1;
            charX = 3;
            charY = 6;

            PreMade();
        }

        void PreMade()
        {
            name = "Priam";
            strength = 5;
            agility = 4;
            magic = 1;

            DerivedStats();
            charstate = 6;

            weapon = 1;
            armour = 1;
            gear1 = 1;
            gear2 = 0;
            motive = 1;
            gold = 0;

            //inDungeon = true;

        }

        void DerivedStats()
        {
            maxHP = 8 + (strength * 2);
            currentHP = maxHP;
            maxMana = magic;
            currentMana = magic;
            //mincombat 45
            combat = 30 + (strength * 9) + (agility * 6);
            //minstealth 16
            stealth = 10 + (agility * 6);
        }

        public void LoadContent(ContentManager content)
        {
            backfill = content.Load<Texture2D>("backfill");
            font = content.Load<SpriteFont>("font");

        }

        public void Update(GameTime gametime)
        {
            inDungeon = true;

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
                        //Move char west on 'A'
                        if (currentKeys[i] == Keys.A || currentKeys[i] == Keys.Left) charX -= 1;
                        if (charX < 0) charX = 0;
                        //Move char north on 'W'
                        if (currentKeys[i] == Keys.W || currentKeys[i] == Keys.Up) charY -= 1;
                        if (charY < 0) charY = 0;
                        //Move char south on 'S'
                        if (currentKeys[i] == Keys.S || currentKeys[i] == Keys.Down) charY += 1;
                        if (charY > 6) charY = 6;
                        //Move char east on 'D'
                        if (currentKeys[i] == Keys.D || currentKeys[i] == Keys.Right) charX += 1;
                        if (charX > 6) charX = 6;
                        //Back to menu on 'ESC'
                        if (currentKeys[i] == Keys.Escape) backToMenu = true;

                    }
                }
            }
            //prepare to collect new key inputs, unload currentKeys
            oldKeys = currentKeys;

        }

        public void Draw(SpriteBatch spritebatch)
        {

            spritebatch.Draw(backfill, statRec, Color.White);
            spritebatch.Draw(backfill, gearRec, Color.SandyBrown);
            spritebatch.DrawString(font, name +"\n\nStrength: " + strength.ToString() + 
                "\nAgility: " + agility.ToString() + "\nMagic: " + magic.ToString() + 
                "\n\nHit Points: " + currentHP.ToString() + " / " + maxHP.ToString() + 
                "\nPower: " + currentMana.ToString() + " / " + maxMana.ToString() + 
                "\n\nCombat Rating: " + combat.ToString() + "\nStealth Rating: " + stealth.ToString()
                + "\n\n\n" + weaponlist.list[weapon].name + "\n" + armourlist.list[armour].name
                + "\n" + gearlist.list[gear1].name + "\n" + gearlist.list[gear2].name, 
                statPos, Color.Black);

        }


    }
}
