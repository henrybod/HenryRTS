using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Task {
        //a controllable unit is given tasks to perform
        public enum TaskEnum {
            //here is a list of all the possible actions a ControllableObject may perform
            Move,
            Follow,
            Attack,
            Repair,
            Mine,
            HoldPosition,
            Idle
        }

        public bool Finished = false;
        

        //a task tells a unit what to do
        public virtual void Update(ControllableObject actor) {

        }
    }

}
