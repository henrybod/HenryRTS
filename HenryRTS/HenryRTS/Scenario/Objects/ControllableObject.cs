using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class ControllableObject : SelectableObject {
        //a controllable object requires two things:
        //1: a 'target' to take action towrds
        //2: an owner player to restrict commands

        public MapObject Target;
        public Player Owner;


        public ControllableObject(Player owner, Map m, Zone initialBounds) : base(m, initialBounds) {
            Owner = owner;
            //todo: rework controllable object and unit for better control system
            //todo: add new classes "moving object" and "pathing object"
        }

        protected virtual void DetermineState() {
            //a controllable object may be given orders by setting the Target
            //by looking at the type of the Target, it must determine its state
        }
        protected virtual void TakeAction() {
            //by looking at the state, a controllable object must take an appropriate action
        }
    }
}
