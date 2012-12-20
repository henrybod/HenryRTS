using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Tree : Resource {

        private static readonly Point treeSize = new Point(16, 10);

        public Tree(Map m, Point initialPosition) : base(m, new Zone(initialPosition.X, initialPosition.Y, treeSize.X, treeSize.Y)) {
            //set sprite(s)
            AddSprite("Idle", "Tree2", new Point(0, -30));
            DrawBorder = true;
            
            //set default resources for tree
            AddElement(1, 20);
            AddElement(2, 12);
            AddElement(3, 13);
            AddElement(4, 2);
            AddElement(5, 20);


        }

    }
}
