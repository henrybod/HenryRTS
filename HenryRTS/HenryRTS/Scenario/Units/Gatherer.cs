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

        public Gatherer(Player owner, Map m, Point initialPosition) : base(owner, m, new Zone(initialPosition.X, initialPosition.Y, GathererSize.X, GathererSize.Y)) {
            Sprites["Idle"].Sprite.SpriteName = "GathererIdle";
            selectionCircleOffset = 16;
            healthMax = GathererHealth;
            health = healthMax;
        }

        protected override void DetermineState() {
            base.DetermineState(); //get default state
            //possibly override that state according to my specific function as a gatherer
            if (Target is Resource) {
                
            }
        }

    }
}
