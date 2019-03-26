using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Dungeon_Floor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Rectangle fullWorld;
        Tile[,] tiles;
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            fullWorld = new Rectangle(0, 0, 32 * 200, 32 * 125);
            tiles = new Tile[200, 125];
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D[] textures = new Texture2D[65];

            for (int i = 0; i < 65; i++)
            {
                textures[i] = Content.Load<Texture2D>("tile" + (i + 1));
            }

            int[] singles = { 1, 2, 3, 4, 5, 6, 7, 17, 18, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 49, 59, 60, 65 };

            Random r = new Random();

            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 125; y++)
                {
                    if (tiles[x, y] != null)
                    {
                        //8 -> 16
                        //19 -> 21
                        //22 -> 24
                        //42 -> 48
                        //50 -> 58
                        //61 -> 64
                        int nextTile = r.Next(singles.Length + 6); // TODO One for each image set. (like 1 for each single, then 1 for each macro image (made of smaller ones))
                        if (nextTile < singles.Length)
                        {
                            nextTile = singles[nextTile];
                            tiles[x, y] = new Tile(x, y, textures[nextTile - 1]);
                        }
                        else
                        {
                            nextTile -= singles.Length;
                            switch (nextTile)
                            {
                                case 0:
                                    nextTile = 8;
                                    tiles[x, y] = new Tile(x, y, textures[7]);
                                    tiles[x + 1, y] = new Tile(x + 1, y, textures[8]);
                                    tiles[x + 2, y] = new Tile(x + 2, y, textures[9]);

                                    tiles[x, y + 1] = new Tile(x, y + 1, textures[10]);
                                    tiles[x + 1, y + 1] = new Tile(x + 1, y + 1, textures[11]);
                                    tiles[x + 2, y + 1] = new Tile(x + 2, y + 1, textures[12]);

                                    tiles[x, y + 2] = new Tile(x, y + 2, textures[13]);
                                    tiles[x + 1, y + 2] = new Tile(x + 1, y + 2, textures[14]);
                                    tiles[x + 2, y + 2] = new Tile(x + 2, y + 2, textures[15]);
                                    break;
                                case 1:
                                    nextTile = 19;
                                    tiles[x, y] = new Tile(x, y, textures[18]);
                                    tiles[x + 1, y] = new Tile(x + 1, y, textures[19]);
                                    tiles[x + 2, y] = new Tile(x + 2, y, textures[20]);                                    
                                    break;
                                case 2:
                                    nextTile = 22;
                                    tiles[x, y] = new Tile(x, y, textures[21]);
                                    tiles[x, y + 1] = new Tile(x, y + 1, textures[22]);
                                    tiles[x, y + 2] = new Tile(x, y + 2, textures[23]);
                                    break;
                                case 3:
                                    nextTile = 42;
                                    break;
                                case 4:
                                    nextTile = 50;
                                    break;
                                case 5:
                                    nextTile = 61;
                                    break;                                                          
                            }
                        }
                    }
                }
            }


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
