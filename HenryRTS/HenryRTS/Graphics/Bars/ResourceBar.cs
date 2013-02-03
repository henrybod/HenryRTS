using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class ResourceBar : ProgressBar {
        //this special type of bar is for Resource objects and display all the elements
        //contained by the Resource according to color and percentage

        public ResourceBar(Zone initialBounds) : base(initialBounds) {

        }

        public void Draw(Resource r) {
            
            //draw the border
            pixel.Color = BorderColor;
            pixel.Draw(new Zone(Bounds.Left, Bounds.Top, Bounds.Width - 1, Bounds.Height));

            //draw each element
            Zone z = new Zone(Bounds.Left + BorderThickness, Bounds.Top + BorderThickness, 0, 0);
            z.Bottom = Bounds.Bottom - BorderThickness;
            float percentageComplete = 0.0f;
            for (int i = 0; i < 88; i++) {
                if (r.Elements[i] == 0) continue; //only proceed if there's something worth drawing
                pixel.Color = Elements.GetElement(i).Color; //draw it the corresponding element color
                float width = ((float)r.Elements[i] / (float)r.TotalUnits) * ((float)Bounds.Width - 2 * BorderThickness);

                z.Right = (int)(Bounds.Left + BorderThickness + percentageComplete * (Bounds.Width - 2 * BorderThickness) + width);
                z.Left = (int)(Bounds.Left + BorderThickness + percentageComplete * (Bounds.Width - 2 * BorderThickness));

                percentageComplete += (float)r.Elements[i] / (float)r.TotalUnits;
                
                pixel.Draw(z);
            }
        }





    }
}
