using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class EmptySpace : MapObject {
        //this class is used by MapObject and Map to designate an empty area of the map

        public EmptySpace(Map m, Zone bounds) : base(m, bounds) {

        }

    }
}
