using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class BigAssWall : Building {
        public static readonly Point BigAssWallDimensions = new Point(30, 40);

        public BigAssWall(Player p, Map m, Point position) : base(p, m, new Zone(position.X, position.Y, BigAssWallDimensions.X, BigAssWallDimensions.Y)) {
            Position = position.Vector;
        }


    }
}
