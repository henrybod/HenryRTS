using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Win32;

namespace HenryRTS {
    public class ControllableObject : SelectableObject {
        //a controllable object requires two things:
        //1: a 'target' to take action towrds
        //2: an owner player to restrict commands

        protected Queue<Task> Tasks = new Queue<Task>();
        protected Task currentTask;
        public Player Owner;


        public ControllableObject(Player owner, Zone initialBounds) : base(initialBounds) {
            Owner = owner;
            Owner.AddObject(this);
            currentTask = new IdleTask();
            currentTask.Finished = true;
        }

        protected virtual void DetermineState() {
            //a controllable object may be given orders by setting the Target
            //by looking at the type of the Target, it must determine its state
        }
        protected virtual void TakeAction() {
            //by looking at the state, a controllable object must take an appropriate action
        }

        public void SetTask(Task t) {
            if (Tasks.Count > 0)
                Tasks.Clear();
            Tasks.Enqueue(t);
        }

        public void EnqueueTask(Task t) {
            Tasks.Enqueue(t);
        }

        public override void Update() {
            base.Update();

            //i have tasks to perform...
            //decide what task to perform
            if (currentTask.Finished) { //wait until task is finished to change tasks
                //i have finished my current task
                if (Tasks.Count > 0) //if i have more tasks...
                    currentTask = Tasks.Dequeue(); //start the next one
                else //if i am out of tasks...
                    currentTask = new IdleTask(); //then i am idle
            }
            
            //do the current task
            currentTask.Update(this);
        }

        protected override void Die() {
            //remove myself from my owner's list of objects
            Owner.RemoveObject(this);
            base.Die(); //remove from map
        }
    }
}
