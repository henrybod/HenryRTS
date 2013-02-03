using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Tree : Resource {

        private static readonly Point treeSize = new Point(16, 10);

        public Tree(Point initialPosition) : base(new Zone(initialPosition.X, initialPosition.Y, treeSize.X, treeSize.Y)) {
            //set sprite(s)
            DrawBorder = true;
            
            //set default resources for tree
            //todo: randomize values somewhat
            AddElement(1, 20);
            AddElement(2, 12);
            AddElement(3, 13);
            AddElement(4, 2);
            AddElement(5, 20);

            //set animations
            Idle = new Animation("Tree2");
            BeingMined = new Animation("Tree2");
            Consumed = new Animation("Tree2");
            Offset = new Point(0, -30);
        }

    }
}
