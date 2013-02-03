using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryRTS {
    public class MoveTask : Task {

        private Stack<Point> path = new Stack<Point>();
        private Point destination;
        private bool initialized = false;

        public MoveTask(Point destination) {
            this.destination = destination;
            
        }

        public override void Update(ControllableObject actor) {
            if (!(actor is Unit)) //this ain't a unit! ...it can't move!
                return;

            if (!initialized) { //get a path if i haven't already
                path = Scenario.Map.GetPath(new Point((int)actor.Position.X, (int)actor.Position.Y), destination, new Point(actor.Width, actor.Height));
                destination = path.Pop();
                initialized = true;
            }

            if (actor.Position != destination.Vector) {
                //i am headed to a point in my path
                actor.Position = Global.MoveLinearly(actor.Position, 40, destination.Vector);

            } else if (actor.Position == destination.Vector && path.Count > 0) {
                //i have reached a point in my path, but have more points to go; head to next point
                destination = path.Pop();

            } else if (actor.Position == destination.Vector && path.Count == 0) {
                //i am done moving
                Finished = true;
            }
        }






    }
}
