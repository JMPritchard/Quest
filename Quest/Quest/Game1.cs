using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Quest
{
    /*
     * 
     * 
     * 
     * towntheme music https://opengameart.org/content/town-theme-rpg
     * 
     * 
     */





    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spritebatch;
        Background background;
        Menu menu;
        Character character;
        Dungeon dungeon;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 692;
            graphics.PreferredBackBufferWidth = 1300;

            this.Window.Title = "QUEST";
            Content.RootDirectory = "Content";
        }
       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            //create game objects
            spritebatch = new SpriteBatch(GraphicsDevice);
            background = new Background();
            menu = new Menu();
            character = new Character();
            dungeon = new Dungeon();


            //LoadContent methods
            background.LoadContent(Content);
            menu.LoadContent(Content);
            character.LoadContent(Content);
            dungeon.LoadContent(Content);


        }
      
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            background.Update(gameTime, character.inDungeon);

            //check for user exit from menu
            if (menu.gamestate == 6) Exit();

            //check for return to Menu
            if (character.backToMenu)
            {
                menu.gamestate = 1;
                //reset backToMenu toggle
                character.backToMenu = false;
            }

            //Update methods
                //if not in game, update menu
            if(menu.gamestate != 3) menu.Update(gameTime);
                //otherwise update character
            else
            {
                character.Update(gameTime);
                dungeon.Update(gameTime, character.charX, character.charY);

            }




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spritebatch.Begin();
            
            background.Draw(spritebatch, character.inDungeon);

            if(menu.gamestate != 3) menu.Draw(spritebatch);
            else
            {
                character.Draw(spritebatch);
                dungeon.Draw(spritebatch, character.charX, character.charY);

            }




            spritebatch.End();

            base.Draw(gameTime);
        }
    }
}
