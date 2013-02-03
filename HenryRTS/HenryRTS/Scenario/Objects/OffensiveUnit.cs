using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class OffensiveUnit : Unit {

        //this is a unit with weaponry
        Weapon myWeapon;

        public OffensiveUnit(Player owner, Zone bounds) : base(owner, bounds) {
        }

        protected override void TakeAction() {
 	        base.TakeAction();
            if (currentTask is AttackTask) {
                SelectableObject target = ((AttackTask)currentTask).Target;
                if ((target.Center - this.Center).Vector.Length() - (target.Center - new Point(target.Right, target.Bottom)).Vector.Length() - (this.Center - new Point(this.Right, this.Bottom)).Vector.Length() <= myWeapon.Range)
                    myWeapon.FireAt(target.Center);
            }
        }
        
    }
}
