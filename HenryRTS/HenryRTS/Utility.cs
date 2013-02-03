using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Utility {
        private static Sprite pixel;

        public static void DrawPixel(Point position, Color color) {
            DrawPixel(new Zone(position.X, position.Y, 1, 1), color);
        }
        public static void DrawPixel(Zone bounds, Color color) {
            if (pixel == null)
                pixel = new Sprite("WhitePixel");
            pixel.Color = color;
            pixel.Draw(bounds);
        }




    }
}
