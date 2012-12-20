using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class ProgressBar : BoundedObject {

        private float factorFull = 1.0f;
        public float FactorFull {
            get { return factorFull; }
            set {
                if (value >= 0.0f && value <= 1.0f)
                    factorFull = value;
            }
        }
        protected Sprite pixel = new Sprite("WhitePixel");
        public Color BorderColor = Color.Black, FillColor1 = Color.LimeGreen, FillColor2 = Color.DarkRed;
        protected int borderThickness = 1;
        public int BorderThickness {
            get { return borderThickness; }
            set {
                if (value >= 0)
                    borderThickness = value;
            }
        }


        public ProgressBar(Zone bounds) {
            Bounds = bounds;
        }

        public override void Draw() {
            Zone z = new Zone(Bounds.Center.X, Bounds.Center.Y, 0, 0);
            //draw the border
            pixel.Color = BorderColor;
            pixel.Draw(Bounds);
            //draw the left half
            pixel.Color = FillColor1;
            z.Left = Bounds.Left + BorderThickness;
            z.Top = Bounds.Top - BorderThickness;
            z.Bottom = Bounds.Bottom + BorderThickness;
            z.Right = z.Left + (int)(factorFull * (Bounds.Width - 2 * BorderThickness));
            pixel.Draw(z);
            //draw the right half
            pixel.Color = FillColor2;
            z.Right = Bounds.Right - BorderThickness;
            z.Left = z.Right - (int)((1.0f - factorFull) * (Bounds.Width - 2 * BorderThickness));
            pixel.Draw(z);
            
        }




    }
}
