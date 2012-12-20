using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class SpriteGroup : MapObject {
        //this is a drawable object with one or more sprites to its name
        protected Dictionary<string, GroupedSprite> Sprites = new Dictionary<string, GroupedSprite>();
        public bool FitSpritesToBounds = false;
        private Sprite pixel = new Sprite("WhitePixel");

        public SpriteGroup(Map m, Zone initialBounds) : base(m, initialBounds) {
            
        }

        public override void Update() {
            base.Update();
            foreach (GroupedSprite gs in Sprites.Values)
                gs.Sprite.Update();
        }

        public override void Draw() {
            base.Draw();
            foreach (GroupedSprite gs in Sprites.Values) {
                if (gs.IsVisible) {
                    if (FitSpritesToBounds)
                        gs.Sprite.Draw(new Zone(Left, Top, Width, Height));
                    else {
                        Zone z = new Zone(0, 0, gs.Sprite.Bounds.Width, gs.Sprite.Bounds.Height);
                        z.Center = Center + gs.Offset;
                        gs.Sprite.Draw(z);
                    }
                }
            }
        }

        public void AddSprite(string index, string spriteName, Point offset, bool isVisible = true) {
            GroupedSprite gs = new GroupedSprite();
            gs.Sprite = new Sprite(spriteName);
            gs.Offset = offset;
            gs.IsVisible = isVisible;
            Sprites.Add(index, gs);
        }

    }


    public class GroupedSprite {
        public Sprite Sprite;
        public Point Offset; //the offset from the bounds of the sprite group
        public bool IsVisible; //should this particular sprite be drawn?

    }

}
