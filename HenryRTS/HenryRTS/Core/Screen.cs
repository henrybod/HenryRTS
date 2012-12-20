using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryRTS {
    public class Screen {

        protected Sprite background;
        public Zone Bounds;

        public Screen(string backgroundSpriteName = "None") {
            
            background = new Sprite(backgroundSpriteName);
            Bounds = new Zone(0, 0, background.Bounds.Width, background.Bounds.Height);

        }

        public virtual void Draw() {
            background.Draw();
        }

        public virtual void Update() {
            background.Update();
        }

    }
}
