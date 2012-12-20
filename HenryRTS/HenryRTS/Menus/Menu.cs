using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Menu : Screen {

        //a menu is a type of screen that has buttons on it!
        protected List<Button> Buttons = new List<Button>();

        public Menu() : base("MenuBackgroundDefault") {
            //a menu will fit its bounds to the camera
            Bounds = new Zone(Global.Camera.TopLeftCorner.X, Global.Camera.TopLeftCorner.Y,
                                (Global.Camera.Center.X - Global.Camera.TopLeftCorner.X) * 2,
                                (Global.Camera.Center.Y - Global.Camera.TopLeftCorner.Y) * 2);
            background.Bounds.Center = Bounds.Center;
        }

        public override void Update() {
            //update buttons
            foreach (Button b in Buttons)
                b.Update();
            base.Update();
        }

        public override void Draw() {
            //draw background
            base.Draw();
            //draw buttons
            foreach (Button b in Buttons)
                b.Draw();
            
        }

    }
}
