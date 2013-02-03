using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Building : ControllableObject {

        public enum BuildingStates {
            Idle,
            Producing,
            Attacking, //for defensive structures
            Dying,
            UnderConstruction
        }

        protected int health;
        public int Health {
            get { return health; }
        }
        protected int healthMax;
        public int HealthMax {
            get { return healthMax; }
        }





        public Building(Player owner, Map m, Zone initialBounds) : base(owner, initialBounds) {

        }
    }
}
