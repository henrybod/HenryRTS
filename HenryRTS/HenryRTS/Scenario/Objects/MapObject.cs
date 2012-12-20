using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class MapObject {

        //this is an object that may be added to the map

        //so it has a bounds to keep track of its own dimensions
        private Zone bounds;
        //it belongs on a map
        private Map myMap;

        public int Left {
            get { return bounds.Left; }
        }
        public int Right {
            get { return bounds.Right; }
        }
        public int Top {
            get { return bounds.Top; }
        }
        public int Bottom {
            get { return bounds.Bottom; }
        }
        public Point Center {
            get { return bounds.Center; }
        }
        public int Width {
            get { return bounds.Width; }
        }
        public int Height {
            get { return bounds.Height; }
        }

        //its children can only set the position, not the bounds
        private Vector2 position; //the center of the MapObject
        public Vector2 Position {
            get { return position; }
            set {
                //when the position is changed, the MapObject updates its place in the GameGrid
                
                if (value == position)
                    return; //the value hasnt actually changed, so there's nothing to do

                //move the object in the grid (to the nearest integer value)
                myMap[bounds.Left, bounds.Top] = new EmptySpace(myMap, bounds);
                myMap[(int)value.X - (int)(bounds.Width/2), (int)value.Y - (int)(bounds.Height/2)] = this;

                //move the bounds
                bounds.Center = new Point((int)value.X, (int)value.Y);

                //save value
                position = value;
            }
        }
        //it may also draw a border around its bounds (for diagnostic purposes)
        public bool DrawBorder = false;
        private Sprite pixel = new Sprite("WhitePixel");


        public MapObject(Map m, Zone initialBounds) {
            this.bounds = initialBounds;
            this.bounds.LockDimensions = true;
            this.position = new Vector2(-1, -1);
            this.myMap = m;
            if (!(this is EmptySpace || this is Location)) {
                //set the position of this object to place in the map array
                Position = new Vector2(bounds.Left, bounds.Top);
                //add this object to the list of map objects
                m.AddObject(this);
            }
            this.position = bounds.Center.Vector;

            //development diagnostic
            DrawBorder = true;
        }


        //a map object may be updated and drawn
        public virtual void Update() {

        }
        public virtual void Draw() {
            if (DrawBorder) {
                Zone z = new Zone();
                z.Center = Center;
                //top line
                z.Left = Left - 1;
                z.Top = Top - 1;
                z.Right = Right;
                z.Bottom = Top;
                pixel.Draw(z);
                //right line
                z.Right = Right + 1;
                z.Left = Right;
                z.Bottom = Bottom;
                pixel.Draw(z);
                //bottom line
                z.Bottom = Bottom + 1;
                z.Top = Bottom;
                z.Left = Left;
                pixel.Draw(z);
                //left line
                z.Left = Left - 1;
                z.Right = Left;
                z.Top = Top;
                pixel.Draw(z);
            }
        }

        protected Stack<Point> GetPath(Point a, Point b) {
            return myMap.GetPath(a, b);
        }
    }
}
