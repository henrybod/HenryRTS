using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class AnimatedMapObject : MapObject {

        Animation animation;
        public bool IsPlaying {
            get { return (animation != null); }
        }
        private Point offset = new Point(0, 0);
        protected Point Offset {
            get { return offset; }
            set {
                offset = value;
            }
        }

        public AnimatedMapObject(Zone bounds) : base(bounds) {

        }

        protected void Play(Animation a) {
            if (animation != a)
                animation = a;
        }

        public override void Update() {
            base.Update();
            if (animation != null) {
                if (animation.Finished)
                    animation = null;
                else {
                    animation.Bounds.Center = this.Center + offset;
                    animation.Update();
                }
            }
        }

        public override void Draw() {
            base.Draw();
            if (animation != null)
                animation.Draw();
        }

    }
}
