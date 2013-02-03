using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryRTS {
    public class Cache : Building {
        //this special type of building accepts resources from gatherers

        public static readonly Point CacheSize = new Point(100, 100);

        public Cache(Player owner, Map m, Point position) : base(owner, m, new Zone(position.X, position.Y, CacheSize.X, CacheSize.Y)) {

        }

        //todo: need a way for gatherers to quickly find the nearest cache
        //perhaps have a general method for finding things
    }
}
