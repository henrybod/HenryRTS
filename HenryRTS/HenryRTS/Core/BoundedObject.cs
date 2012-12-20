using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class BoundedObject {

        public Zone Bounds;

        public BoundedObject() {
            Bounds = new Zone(0, 0, 0, 0);
        }

        public BoundedObject(Zone initialBounds) {
            Bounds = initialBounds;
        }

        public virtual void Update() {

        }
        
        public virtual void Draw() {

        }
    }
}
