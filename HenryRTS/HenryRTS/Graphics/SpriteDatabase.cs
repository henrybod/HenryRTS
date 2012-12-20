using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HenryRTS {

    public class SpriteDatabase {

        public Dictionary<string, SpriteInfo> Infos = new Dictionary<string, SpriteInfo>();
        public Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();


        public SpriteDatabase() {
            //populate the dictionary
            //>>>format: filepath, texture name, height, width, # of frames<<<
            //Empty texture
            AddEntry("Textures/None", "None", 1, 1, 1);
            //Single white pixel for drawing
            AddEntry("Textures/Pixel", "WhitePixel", 1, 1, 1);
            //Menu background image
            AddEntry("Textures/MenuBackgroundDefault", "MenuBackgroundDefault", 900, 1440, 1);
            //HUD items
            AddEntry("Textures/HUD", "CursorMenu", 16, 16, 1);
            AddEntry("Textures/HUD", "ButtonDefaultIdle", 64, 128, 8);
            AddEntry("Textures/HUD", "ButtonDefaultHighlighted", 64, 128, 8);
            AddEntry("Textures/HUD", "ButtonDefaultPressed", 64, 128, 8);
            AddEntry("Textures/HUD", "ButtonDefaultDisabled", 65, 128, 8);
            AddEntry("Textures/HUD", "SelectionCircleSmall", 12, 31, 1);
            //units
            AddEntry("Textures/Units", "GathererIdle", 36, 29, 1);
            //environment
            AddEntry("Textures/tree", "Tree1", 256, 256, 1);
            AddEntry("Textures/NewTree", "Tree2", 64, 64, 1);
            AddEntry("Textures/SeemlessDirt", "Dirt", 2000, 2000, 1);
        }

        private void AddEntry(string file, string index, int height, int width, int frameCount) {
            //add to Infos
            SpriteInfo si = new SpriteInfo();
            si.Filename = file;
            foreach (SpriteInfo s in Infos.Values)
                if (s.Filename == si.Filename)
                    si.Frame.Y += s.Frame.Height;
            si.Frame.X = 0;
            si.Frame.Width = width;
            si.Frame.Height = height;
            si.FrameCount = frameCount;
            Infos.Add(index, si);

            //add to Textures
            if (!Textures.ContainsKey(file))
                Textures.Add(file, Global.Content.Load<Texture2D>(file));
        }

        public void SpriteDiag(string spriteName) {
            SpriteInfo s = Infos[spriteName];
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Sprite Entry \"" + spriteName + "\":");
            Console.WriteLine("-->Filename = " + s.Filename);
            Console.WriteLine("-->Frame = " + s.Filename);
            Console.WriteLine("  -->Width = " + s.Frame.Width);
            Console.WriteLine("  -->Height = " + s.Frame.Height);
            Console.WriteLine("  -->X = " + s.Frame.X);
            Console.WriteLine("  -->Y = " + s.Frame.Y);
            Console.WriteLine("-->FrameCount = " + s.FrameCount);
            Console.WriteLine("-------------------------------------");

        }
    }


    public struct SpriteInfo {
        public string Filename;
        public Rectangle Frame;
        public int FrameCount;
    }
}
