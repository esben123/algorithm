using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Algorithm
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<GameObject> allGameObjects = new List<GameObject>();
        List<GameObject> toBeAdded = new List<GameObject>();
        List<GameObject> toBeRemoved = new List<GameObject>();

        private static Vector2 shopDimensions;
        private static GameObject[,] shopGo;

        private static GameWorld instance;
        public static GameWorld Instance
        {

            get
            {
                if (instance == null)
                    instance = new GameWorld();

                return instance;
            }
        }

        public static Vector2 ShopDimensions { get => shopDimensions; }
        public static GameObject[,] ShopGo { get => shopGo; set => shopGo = value; } 

        public GameWorld()
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
            // TODO: Add your initialization logic here

            base.Initialize();
            shopDimensions = new Vector2(17, 13);

            shopGo = new GameObject[(int)shopDimensions.X, (int)shopDimensions.Y];

            for (int y = 1; y < shopDimensions.Y; y++)
            {
                for (int x = 1; x < shopDimensions.X; x++)
                {
                    TileFactory.Instance.create("floor", new Point(x, y));
                }
            }
            TileFactory.Instance.create("helmets", new Point(7, 1));
            TileFactory.Instance.create("book_big", new Point(2, 1));
            TileFactory.Instance.create("book_small", new Point(3, 5));
            TileFactory.Instance.create("spear", new Point(8, 10));
            TileFactory.Instance.create("torso", new Point(12, 1));


            Grid testGrid = new Grid();
            testGrid.CreateGrid();
            ShopperFactory.Instance.create("shopper", new Point(1, 10));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
           // font = Content.Load<SpriteFont>("font");

            

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public void AddGameObject(GameObject obj)
        {
            toBeAdded.Add(obj);
        }

        
        public void RemoveGameObject(GameObject obj)
        {
            toBeRemoved.Add(obj);
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach (GameObject go in toBeAdded)
            {
                allGameObjects.Add(go);
            }
            toBeAdded.Clear();

            foreach (GameObject go in toBeRemoved)
            {
                allGameObjects.Remove(go);
            }
            toBeRemoved.Clear();

            foreach (GameObject go in allGameObjects)
            {
                go.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred);

            foreach (GameObject go in allGameObjects)
            {
                go.Draw(spriteBatch);
            }

            spriteBatch.End();
         

            base.Draw(gameTime);
        }
    }
}
