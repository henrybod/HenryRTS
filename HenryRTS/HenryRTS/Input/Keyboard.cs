using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HenryRTS {
    public class Keyboard {

        //list of established game keys (keybinds are below in Update())
        public bool Up = false;
        public bool Down = false;
        public bool Left = false;
        public bool Right = false;

        public bool W = false;
        public bool S = false;
        public bool A = false;
        public bool D = false;

        public bool Enter = false;
        public bool Back = false;
        public bool Shift = false;

        public void Update() {
            //get all the key values for this frame
            KeyboardState k = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            Up = k.IsKeyDown(Keys.Up);
            Down = k.IsKeyDown(Keys.Down);
            Left = k.IsKeyDown(Keys.Left);
            Right = k.IsKeyDown(Keys.Right);

            W = k.IsKeyDown(Keys.W);
            S = k.IsKeyDown(Keys.S);
            A = k.IsKeyDown(Keys.A);
            D = k.IsKeyDown(Keys.D);

            Enter = k.IsKeyDown(Keys.Enter);
            Back = k.IsKeyDown(Keys.Back); //todo: test to see if 'back' is 'backspace'
            Shift = k.IsKeyDown(Keys.LeftShift) || k.IsKeyDown(Keys.RightShift);
            //todo: come up with a way the user could use custom keybinds
        }

        public Vector2 ArrowKeysUnitVector {
            get {
                Vector2 d = Vector2.Zero;
                if (Left)
                    d.X -= 1;
                if (Right)
                    d.X += 1;
                if (Up)
                    d.Y -= 1;
                if (Down)
                    d.Y += 1;
                if (d != Vector2.Zero)
                    d.Normalize();
                return d;
            }
        }





    }
}
