using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Game9
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ResolutionManager resolutionManager;
        Camera camera;


        int blockSize = 128;

        int rowHit;

        int drawTimer = 15;
        int drawCooler = 0;

        Texture2D texture;
        Texture2D wallpaper;
        Texture2D hero_texture;
        Texture2D hand;
        Texture2D bullet;
        SpriteFont font;

        Hero hero;
        LevelManager level;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            resolutionManager = new ResolutionManager();
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;

            reset();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            camera = new Camera(GraphicsDevice.Viewport);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("block");
            wallpaper = Content.Load<Texture2D>("wall");
            hero_texture = Content.Load<Texture2D>("mine");
            hand = Content.Load<Texture2D>("hand");
            bullet = Content.Load<Texture2D>("bullet");
            font = Content.Load<SpriteFont>("File");
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            if (hero != null) hero.Update(touchCollection);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            camera.Update(hero);
            resolutionManager.Update();
            base.Update(gameTime);

            checkCollition();

            if (drawCooler > 0) drawCooler--;
            if (drawCooler < 0) drawCooler = 0;
        }
        private void checkCollition()
        {
            if (hero == null || level == null) return; // Ja e er moet wel iets zijn om te controleren

            int countBlock = 0;
            int countSpace = 0;

            for(int x = 0; x < level.getMap().Count; x ++)
            //foreach(var row in level.getMap())
            {
                var row = level.getMap()[x];

                for(int i = 0; i < row.Length; i++)
                {
                    if (row[i] == null) continue;

                    if (row[i].CollitionRect().Intersects(hero.CollitionRect()))
                    {
                        if (x > 3 && row[i] is GateBlock) countSpace++;
                        if (row[i] is StaticBlock) countBlock++;
                        if(row[i] is GateBlock && rowHit < x)
                        {
                            hero.Score();
                        }
                        rowHit = x;
                    }
                }

                if(hero.Position.Y > level.heightCount * GameConf.BlockSize || hero.Position.Y < 0)
                {
                    countBlock++;
                }
            }

            if (countSpace > 0) level.addRow();
            if (countBlock > 0) die();

            //hero.updateCanMove(countBlock == 0);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            if (drawCooler != 0) return;
            if (texture == null) return;
            
            spriteBatch.Begin();

            spriteBatch.Draw(wallpaper, new Vector2(0, 0), new Rectangle(0, 0, 1080, 1920), Color.White);

            spriteBatch.End();


            spriteBatch.Begin(transformMatrix: camera.transform);

            
            level.Draw(spriteBatch, texture, wallpaper);
            hero.Draw(spriteBatch, hero_texture, hand, font, bullet);
            base.Draw(gameTime);

            spriteBatch.End();
        }
        private void die()
        {
            reset();
        }
        private void reset()
        {
            makeHeroAndLevel();
            rowHit = -1;
            drawCooler = drawTimer;
        }
        private void makeHeroAndLevel()
        {
            hero = new Hero(new Vector2(450, 1920 / 2), new Rectangle(0, 0, blockSize, blockSize));
            level = new Level_01();
        }
    }
}