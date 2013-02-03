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

namespace HenryRTS {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class HenryRTS : Microsoft.Xna.Framework.Game {

        //temporary testing thingy
        private Tester tester;




        public HenryRTS() {
            Global.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Global.Content = Content;
            Window.AllowUserResizing = false; //todo: implement this functionality
            Global.Window = Window;
            Global.Graphics.PreferredBackBufferWidth = 1024;
            Global.Graphics.PreferredBackBufferHeight = 768;
        }

        protected override void Initialize() {

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            Global.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Global.Camera = new Camera();
            Global.CurrentScreen = new MainMenu();
            Global.Camera.Center = Global.CurrentScreen.Bounds.Center;
            //tester = new Tester(new Zone(100, 100, 100, 100));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //hmmm
            Global.Time = gameTime;
            Global.t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Mouse.Update();
            Keyboard.Update();
            Global.Camera.Update();
            Global.CurrentScreen.Update();
            //tester.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Global.SpriteBatch.Begin();


            Global.CurrentScreen.Draw();
            //tester.Draw();
            Mouse.Draw();


            Global.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
