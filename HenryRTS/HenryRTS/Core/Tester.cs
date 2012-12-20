﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HenryRTS {
    class Tester {

        //Gatherer S = new Gatherer(new Zone(0, 0, 6, 10));
        Sprite pixel = new Sprite("WhitePixel");
        TextSprite ts = new TextSprite();

        public Tester(Zone z) {
            ts.Font = Global.Fonts.Consolas;
            ts.Text = "Test String";
            ts.Origin = Global.Origins.Bottom;
        }

        public void Update() {

            Point offset = new Point(0, 0);
            if (Global.Keyboard.A)
                offset.X -= 1;
            if (Global.Keyboard.D)
                offset.X += 1;
            if (Global.Keyboard.W)
                offset.Y -= 1;
            if (Global.Keyboard.S)
                offset.Y += 1;
            ts.Update();
        }

        public void Draw() {

            ts.Draw();
        }

    }
}

