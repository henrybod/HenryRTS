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
                Scenario.Map[bounds.Left, bounds.Top] = new EmptySpace(bounds);
                Scenario.Map[(int)value.X - (int)(bounds.Width/2), (int)value.Y - (int)(bounds.Height/2)] = this;
                //move the bounds
                bounds.Center = new Point((int)value.X, (int)value.Y);

                //save value
                position = value;
            }
        }
        //it may also draw a border around its bounds (for diagnostic purposes)
        public bool DrawBorder = false;
        private Sprite pixel = new Sprite("WhitePixel");


        public MapObject(Zone initialBounds) {
            this.bounds = initialBounds;
            this.bounds.LockDimensions = true;
            this.position = new Vector2(-1, -1);
            if (!(this is EmptySpace || this is Location)) {
                //set the position of this object to place in the map array
                Position = new Vector2(bounds.Left, bounds.Top);
                //add this object to the list of map objects
                Scenario.Map.AddObject(this);
            }
            this.position = bounds.Center.Vector;

            //development diagnostic
            DrawBorder = true;
        }


        //a map object may be updated and drawn
        public virtual void Update() {

        }
        public virtual void Draw() {
            if (DrawBorder)
                bounds.DrawBorder();
        }

        protected virtual void Die() {
            //remove myself from the map
        }
    }
}
