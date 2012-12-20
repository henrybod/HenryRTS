using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Animation : Sprite {

        //this special type of sprite changes its frame according to FPS and other factors
        //it has multiple types of animations (loop, reverse, etc)

        //data for frame changing
        private int frameCurrent = 0; //the zero-based id # of what frame this sprite is currently displaying
        public int FPS = 1; //the number of frames per second (frameCurrent++ if timeElapsed > 1/FPS)
        private float timeElasped = 0; //the amount of time that has passed since i last advanced the frame
        public enum AnimEnum {
            Normal, //move thru all frames then go back to the beginning
            Reverse, //move thru backwards
            Loop, //move forward to end, then backwards to beginning
        }
        public AnimEnum AnimationMethod = AnimEnum.Normal;
        private bool onTheFlipSideYo = false;

        //constructors
        public Animation() {}
        public Animation(string spriteName) : base(spriteName) {}

        //functions
        private void AdvanceFrame() { //advances to the next frame according to Animation Method
            if (AnimationMethod == AnimEnum.Normal) {
                frameCurrent++;
                if (frameCurrent >= frameCount) //have passed last frame
                    frameCurrent = 0; //wrap around to first frame

            } else if (AnimationMethod == AnimEnum.Reverse) {
                frameCurrent--;
                if (frameCurrent < frameCount) //have passed first frame
                    frameCurrent = frameCount - 1; //wrap around to last frame
            } else if (AnimationMethod == AnimEnum.Loop) {
                if (onTheFlipSideYo)
                    frameCurrent--;
                else
                    frameCurrent++;
                if (frameCurrent >= frameCount - 1) //i am on the last frame
                    onTheFlipSideYo = true; //i should reverse my framing
                else if (frameCurrent <= 0) //i am on the first frame
                    onTheFlipSideYo = false; //i should move forwards
            }

            frame.X = frame.Width * frameCurrent;
        }

        public override void Update() {
            timeElasped += Global.t;
            if (timeElasped >= 1.0f / (float)FPS) {
                timeElasped = 0;
                AdvanceFrame();
            }
        }



    }
}
