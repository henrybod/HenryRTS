using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HenryRTS {
    public class Global {
        private Global(){}
        //xna stuff
        public static ContentManager Content;
        public static SpriteBatch SpriteBatch;
        public static GraphicsDeviceManager Graphics;
        public static GameWindow Window;
        public static GameTime Time;
        public static float t; //time since last frame in seconds
        //menu stuff
        public delegate void ButtonCallback();
        public static Screen CurrentScreen;
        //public static Dictionary<string, Menu> Menus = new Dictionary<string, Menu>();
        //movement stuff
        public enum TravelMethods {
            Instantaneous,
            Elastic,
            Linear,
            Accelerative
        }
        public enum Origins {
            Top,
            Left,
            Bottom,
            Right,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            Center
        }
        public enum GameTypes {
            FreeForAll,
            TeamVsTeam,
            Survival
        }
        public enum MapEnvironments {
            Earth,
            Desert,
            Ice,
            Lava,
            Asteroid
        }
        public enum GenericSizes {
            Small,
            Medium,
            Large,
            VeryLarge,
        }
        public static Vector2 MoveLinearly(Vector2 p1, float vel, Vector2 p2) {
            Vector2 distanceTotal = (p2 - p1);
            if (distanceTotal.Length() == 0)
                return p2;
            Vector2 distanceIncr = Vector2.Normalize(distanceTotal) * vel * t;
            if (distanceIncr.Length() > distanceTotal.Length())
                return p2; //i've gone past p2, return p2
            else
                return p1 + distanceIncr;
        }
        public static Vector2 MoveElastically(Vector2 p1, float vel, Vector2 p2) {
            Vector2 distanceTotal = (p2 - p1);
            Vector2 distanceIncr = distanceTotal * vel * t;
            if (distanceIncr.Length() > distanceTotal.Length())
                return p2; //i've gone past p2, return p2
            else
                return p1 + distanceIncr;
        }
        public static Vector2 MoveAcceleratively(Vector2 p1, ref Vector2 currVel, float acc, Vector2 p2) {
            Vector2 direction = Vector2.Normalize(p2 - p1);
            currVel += direction * acc * Global.t;
            return p1 + (currVel * Global.t);
        }

        public static Camera Camera;
    }
}
