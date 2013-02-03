using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class RandomMap : Map {

        public RandomMap(Point dimensions, Global.MapEnvironments e) : base(dimensions, "RandomMap", e) {

        }

        public void Populate() {
            if (MapType == Global.MapEnvironments.Earth)
                GenerateEarthObjects();
        }

        //generation functions
        private void GenerateEarthObjects() {
            Random r = new Random();

            //probabilities of various objects/areas
            //float probForest = 

            for (float i = 0; i <= 1; i += 0.01f) {
                for (float j = 0; j <= 1; j += 0.01f) {
                    if (r.Next(100) == 1) { //1% chance for coordinate to be the center of a forest
                        GenerateForest(new Point((int)(i * dimensions.X * tileSize.X), (int)(j * dimensions.Y * tileSize.Y)));
                    }
                }
            }
        }

        private void GenerateForest(Point center) {
            Random r = new Random();
            int radius = r.Next(50, 100);
            for (float M = 0; M < radius; M += 1.0f) {
                for (float theta = 0; theta < 2 * Math.PI; theta += (float)(2 * Math.PI / 360)) {
                    if (r.Next(1000) == 1) {
                        new Tree(new Point(center.Vector + new Vector2(M * (float)Math.Cos(theta), M * (float)Math.Sin(theta))));
                    }
                }
            }
        }





    }
}
