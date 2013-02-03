using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Gatherer : Unit {

        public static readonly Point GathererSize = new Point(32, 32);
        public static readonly int GathererHealth = 40;

        public enum GathererStates {
            Moving,
            Idle,
            HoldingPosition,
            Dying,
            Mining
        }

        public Gatherer(Player owner, Point initialPosition) : base(owner, new Zone(initialPosition.X, initialPosition.Y, GathererSize.X, GathererSize.Y)) {
            Idle.SpriteName = "GathererIdle";
            selectionCircleOffset = 16;
            healthMax = GathererHealth;
            health = healthMax;
        }

        protected override void DetermineState() {
            base.DetermineState(); //get default state
            //possibly override that state according to my specific function as a gatherer
            
        }

    }
}
