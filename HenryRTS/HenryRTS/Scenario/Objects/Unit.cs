using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Unit : ControllableObject {

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

        protected Animation Idle, Moving, Attacking, Dying;

        public Unit(Player owner, Zone initialBounds) : base(owner, initialBounds) {
            Idle = new Animation("WhitePixel");
            Idle.Bounds.Width = this.Width;
            Idle.Bounds.Height = this.Height;

            Moving = new Animation("WhitePixel");
            Moving.Bounds.Width = this.Width;
            Moving.Bounds.Height = this.Height;

            Attacking = new Animation("WhitePixel");
            Attacking.Bounds.Width = this.Width;
            Attacking.Bounds.Height = this.Height;

            Dying = new Animation("WhitePixel");
            Dying.Bounds.Width = this.Width;
            Dying.Bounds.Height = this.Height;
        }

        public override void Update() {
            //determine action
            DetermineState();
            //set sprites
            if (unitState == UnitStates.Idle || unitState == UnitStates.HoldingPosition)
                Play(Idle);
            else if (unitState == UnitStates.Moving || unitState == UnitStates.Patrolling)
                Play(Moving);
            else if (unitState == UnitStates.Attacking)
                Play(Attacking);
            else if (unitState == UnitStates.Dying)
                Play(Dying);
            else
                Play(Idle);


            base.Update();
        }

        protected override void DetermineState() {
            if (Health == 0)
                unitState = UnitStates.Dying;
            else if (currentTask is MoveTask)
                unitState = UnitStates.Moving;
            else if (currentTask is IdleTask)
                unitState = UnitStates.Idle;    
        }




        //units may attack things!
        protected void Attack(SelectableObject so) {
            
        }
    }
}
