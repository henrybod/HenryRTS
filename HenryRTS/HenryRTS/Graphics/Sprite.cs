using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HenryRTS {
    public class Sprite : BoundedObject {
        //visual data
        private string texture;
        public string SpriteName {
            set {
                SpriteInfo i = Sprites.Infos[value];
                frame = i.Frame;
                frameCount = i.FrameCount;
                texture = i.Filename;
                nativeTextureSize = new Point(frame.Width, frame.Height);
                Bounds = new Zone(0, 0, frame.Width, frame.Height);
                Bounds.LockDimensions = true;
            }
        }
        protected Rectangle frame; //sprite size & location within texture file
        private Point nativeTextureSize;
        protected int frameCount; //the number of frames for this sprite
        public Color Color = Color.White;
        
        
        
        
        public Sprite(string spriteName = "None") : base() {
            SpriteName = spriteName;
        }

        public void ResetBounds() {
            //restores original height/width to that native to the sprite
            Bounds.Width = nativeTextureSize.X;
            Bounds.Height = nativeTextureSize.Y;
        }

        public override void Update() {

        }

        public override void Draw() {
            //draw this sprite to its current bounds
            Global.SpriteBatch.Draw(Sprites.Textures[texture], Bounds.WindowCoordinates.Rectangle, frame, Color);
        }
        

        public void Draw(Zone z) {
            //draw this sprite to an external Zone
            Global.SpriteBatch.Draw(Sprites.Textures[texture], z.WindowCoordinates.Rectangle, frame, Color);
        }
    }
}
