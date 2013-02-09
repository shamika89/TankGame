using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace TestTank
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        int n = 20;
        int size = 28;
        Texture2D cell;
        Texture2D water_s;
        Texture2D brick;
        Texture2D stone;
        Texture2D coinPile;
        Texture2D lifePack;
        Texture2D backgroundTexture;
        
        Listner listener;
        Writer writer;
        Decoder decoder;
        String str;

        static int screenWidth;
        static int screenHeight;

        private List<Player> players;
        private List<GameObject> water;
        private List<Brick> bricks;
        private List<Coin> coins;
        private List<GameObject> stones;
        private List<Life> lives;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
           
           
            graphics.PreferredBackBufferWidth =800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.IsFullScreen = false;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 1.0f);
            this.IsFixedTimeStep = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            backgroundTexture = Content.Load<Texture2D>("background");
            cell = Content.Load<Texture2D>("cell");
            water_s = Content.Load<Texture2D>("water");
            brick = Content.Load<Texture2D>("brick");
            stone = Content.Load<Texture2D>("stone-wall");
            coinPile = Content.Load<Texture2D>("coin-pile");
            lifePack = Content.Load<Texture2D>("life-pack");
            

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;


            listener = new Listner();
            writer = new Writer();
            decoder = new Decoder();
            writer.sendData("JOIN#");

            //str = listener.receiveData();
            //decoder.decode(str);
            //setUPMap();
           
        }

       
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            str=listener.receiveData();
            decoder.decode(str);
            players = decoder.Players;
            water = decoder.Water;
            bricks = decoder.Bricks;
            stones = decoder.Stone;
            coins = decoder.Coins;
            lives = decoder.Lives;
            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //drawBackground();
            drawGrid();
            drawMapItem();
            spriteBatch.End();
          
            base.Draw(gameTime);
        }

        private void drawBackground()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);

            
        }

        public void drawGrid()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    spriteBatch.Draw(cell, new Rectangle(i * size, j * size, size - 1, size - 1), Color.White);
                    
                }
            }
      
        }

        public void drawMapItem()
        {

            for (int i = 0; i < players.Count; i++)
            {
                int x = players[i].X;
                int y = players[i].Y;
                int dir = players[i].Direction;
                float angle = getAngle(dir);

                spriteBatch.Draw(cell, new Rectangle(x * size, y * size, size - 1, size - 1), Color.Red);
            }
                   
                     foreach (Brick b in bricks)
                     {
                         int i = b.X;
                         int j = b.Y;
                        
                             spriteBatch.Draw(brick, new Rectangle(i * size, j * size, size - 1, size - 1), Color.White);
                         
                     }

                     foreach (GameObject w in water)
                     {
                         int i = w.X;
                         int j = w.Y;
                         
                             spriteBatch.Draw(water_s, new Rectangle(i * size, j * size, size - 1, size - 1), Color.White);
                         
                      }

                     foreach (GameObject s in stones)
                     {
                         int i = s.X;
                         int j = s.Y;
                        
                             spriteBatch.Draw(stone, new Rectangle(i * size, j * size, size - 1, size - 1), Color.White);
                                             
                     }

                     foreach (Coin c in coins)
                     {
                         int i = c.X;
                         int j = c.Y;

                         spriteBatch.Draw(coinPile, new Rectangle(i * size, j * size, size - 1, size - 1), Color.Yellow);

                     }

                     foreach (Life l in lives)
                     {
                         int i = l.X;
                         int j = l.Y;

                         spriteBatch.Draw(lifePack, new Rectangle(i * size, j * size, size - 1, size - 1), Color.White);

                     }
            
        }

        public float getAngle(int dir)
        {
            if (dir == 0)
                return 0;
            else if (dir == 1)
                return (float)MathHelper.PiOver2;
            else if (dir == 2)
                return (float)Math.PI;
            else
                return -(float)MathHelper.PiOver2;

        }

        public void setUPMap()
        {
            players = decoder.Players;
            water = decoder.Water;
            bricks = decoder.Bricks;
            stones = decoder.Stone;
        }

       
    }
}
