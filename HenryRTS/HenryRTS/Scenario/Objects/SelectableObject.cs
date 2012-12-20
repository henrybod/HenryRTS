using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class SelectableObject : SpriteGroup {
        //and interactive object is one that may be clicked on to some advantage in the game
        //it must have everything necessary to be "selected" by the user
        //1: an offset value for the selection circle
        //2: a thumbnail image for the HUD (not yet)
        

        protected int selectionCircleOffset;
        public int SelectionCircleOffset {
            get { return selectionCircleOffset; }
        }


        public SelectableObject(Map m, Zone bounds) : base(m, bounds) {

        }

    }
}
