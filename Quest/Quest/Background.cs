using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class Background
    {
        Texture2D village, dungeon1;
        Vector2 backgroundPos;
        SoundEffect towntheme, azogsmarch;
        SoundEffectInstance townthemeinstance, dungeoninstance;

        bool musicPlaying;
        int musicCounter;

        public Background()
        {
            backgroundPos = new Vector2(0, 0);

            musicPlaying = false;
            musicCounter = 40;

        }

        public void LoadContent(ContentManager content)
        {

            village = content.Load<Texture2D>("village");
            dungeon1 = content.Load<Texture2D>("level1");

            //sound
            towntheme = content.Load<SoundEffect>("TownTheme");
            azogsmarch = content.Load<SoundEffect>("AzogsMarch2");

            townthemeinstance = towntheme.CreateInstance();
            dungeoninstance = azogsmarch.CreateInstance();

        }

        public void Update(GameTime gametime, bool inDungeon)
        {

            if (townthemeinstance.State == SoundState.Stopped && 
                dungeoninstance.State == SoundState.Stopped) musicPlaying = false;

            if (inDungeon)
            {
                if (townthemeinstance.State != SoundState.Stopped) townthemeinstance.Stop();
            }

            if (!musicPlaying)
            {
                musicCounter++;
                if (musicCounter > 80)
                {
                    if (inDungeon) dungeoninstance.Play();
                    else townthemeinstance.Play();
                    musicPlaying = true;
                    musicCounter = 0;
                }
            }

        }

        public void Draw(SpriteBatch spritebatch, bool inDungeon)
        {

            if (!inDungeon) spritebatch.Draw(village, backgroundPos, Color.White);
            else spritebatch.Draw(dungeon1, backgroundPos, Color.White);

        }



    }
}
