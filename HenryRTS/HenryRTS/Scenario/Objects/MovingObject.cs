using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class MovingObject : ControllableObject {

        private Stack<Point> path;
        private Point currentDestination;
        protected bool isMoving = false;
        public enum DirectionEnum {
            N,
            NE,
            E,
            SE,
            S,
            SW,
            W,
            NW
        }
        protected DirectionEnum Direction;

        public MovingObject(Player p, Map m, Zone bounds) : base(p, m, bounds) {
            path = new Stack<Point>(); //start off with no path
            currentDestination = new Point((int)Position.X, (int)Position.Y); //start off headed to where i am
        }

        public void MoveTo(Vector2 destination) {
            MoveTo(new Point((int)destination.X, (int)destination.Y));
        }

        public void MoveTo(Point destination) {
            path = GetPath(new Point((int)this.Position.X, (int)this.Position.Y), destination);
        }

        public override void Update() {
            base.Update();
            if (Position != currentDestination.Vector) {
                //i am headed to a point in my path
                Position = Global.MoveLinearly(Position, 40, currentDestination.Vector);
                isMoving = true;
            } if (Position == currentDestination.Vector && path.Count > 0) {
                //i have reached a point in my path, but have more points to go; head to next point
                currentDestination = path.Pop();
                isMoving = true;
            } else if (Position == currentDestination.Vector && path.Count == 0) {
                //i am done moving
                isMoving = false;
            }
        }


    }
}
