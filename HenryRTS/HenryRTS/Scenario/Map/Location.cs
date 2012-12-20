using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Location : MapObject {
        public Location(Map m, Point p) : base(m, new Zone(p.X, p.Y, 1, 1)) {

        }
    }
}
