using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Unit : MovingObject {

        public enum UnitStates {
            Attacking,
            Moving,
            Idle,
            HoldingPosition,
            Patrolling,
            Dying
        }
        protected UnitStates unitState = UnitStates.Idle;

        protected int health;
        public int Health {
            get { return health; }
        }
        protected int healthMax;
        public int HealthMax {
            get { return healthMax; }
        }
        protected int weaponRange;
        public int WeaponRange {
            get { return weaponRange; }
        }



        public Unit(Player owner, Map m, Zone initialBounds) : base(owner, m, initialBounds) {
            AddSprite("Idle", "GathererIdle", new Point(0, 0), true);
            AddSprite("Moving", "GathererIdle", new Point(0, 0), true);//todo: add moar sprites
            AddSprite("Attacking", "GathererIdle", new Point(0, 0), true);
            //AddSprite("Dying", "GenericSmallExplosion", new Point(0, 0), true);
        }

        public override void Update() {
            //determine action
            DetermineState();
            //set sprites
            Sprites["Idle"].IsVisible = unitState == UnitStates.Idle || unitState == UnitStates.HoldingPosition;
            Sprites["Moving"].IsVisible = unitState == UnitStates.Moving || unitState == UnitStates.Patrolling;
            //take action
            TakeAction();
            base.Update();
        }

        protected override void DetermineState() {
            if (Health == 0)
                unitState = UnitStates.Dying;
            if (this.isMoving)
                unitState = UnitStates.Moving;
            
        }

        protected override void TakeAction() {
            if (unitState == UnitStates.Dying)
                ; //play death animation and remove unit from lists when finished
            if (unitState == UnitStates.Idle)
                //just sit there la dee da
                ;

        }

    }
}
