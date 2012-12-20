using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Camera {

        private Zone Bounds;
        private Vector2 position;
        public Point TopLeftCorner {
            get { return new Point(Bounds.Left, Bounds.Top); }
            set {
                Bounds.Left = value.X;
                Bounds.Top = value.Y;
                position = new Vector2(TopLeftCorner.X, TopLeftCorner.Y);
            }
        }
        public Point Center {
            get { return Bounds.Center; }
            set {
                Bounds.Center = value;
                position = new Vector2(TopLeftCorner.X, TopLeftCorner.Y);
            }
        }
        //Axes not used at the moment
        private Point axes;
        public Point Axes {
            get { return axes; }
            set {
                if (value.X > 0 && value.Y > 0)
                    axes = value;
            }
        }
        private int speed = 20;
        public int Speed {
            get { return speed; }
            set {
                if (value >= 0)
                    speed = value;
            }
        }




        public Camera() {
            //OnScreenResize(Global.Window, new EventArgs());
            //Global.Window.ClientSizeChanged += new EventHandler<EventArgs>(OnScreenResize);
            Bounds = new Zone(0, 0, Global.Window.ClientBounds.Width, Global.Window.ClientBounds.Height);
            Bounds.LockDimensions = true;
        }

        public void Update() {
            Vector2 newPosition = position + speed * Global.Keyboard.ArrowKeysUnitVector;
            if (newPosition != position) {
                //ok, camera must move...
                //check to see if the new camera bounds are within the screen
                Zone newBounds = new Zone(Zone.ZoneModeEnum.GameCoordinates, Bounds.Left, Bounds.Right, Bounds.Width, Bounds.Height);
                newBounds.LockDimensions = true;
                newBounds.Left = (int)newPosition.X;
                newBounds.Top = (int)newPosition.Y;
                if (Global.CurrentScreen.Bounds.Contains(newBounds)) {
                    //the camera's new position will be within the screen
                    position = newPosition;
                    Bounds.Left = (int)newPosition.X;
                    Bounds.Top = (int)newPosition.Y;
                } else {
                    //the camera will not be within the screen, so cull values
                    if (newBounds.Left < Global.CurrentScreen.Bounds.Left)
                        newBounds.Left = Global.CurrentScreen.Bounds.Left;
                    if (newBounds.Right > Global.CurrentScreen.Bounds.Right)
                        newBounds.Right = Global.CurrentScreen.Bounds.Right;
                    if (newBounds.Top < Global.CurrentScreen.Bounds.Top)
                        newBounds.Top = Global.CurrentScreen.Bounds.Top;
                    if (newBounds.Bottom > Global.CurrentScreen.Bounds.Bottom)
                        newBounds.Bottom = Global.CurrentScreen.Bounds.Bottom;
                    position = new Vector2(newBounds.Left, newBounds.Top);
                    Bounds = newBounds;
                }
            }
        }

        private void OnScreenResize(object sender, EventArgs e) {
            GameWindow Window = (GameWindow)sender;
            float aspectRatio = (float)Window.ClientBounds.Width / (float)Window.ClientBounds.Height;
            if (Window.ClientBounds.Width >= Window.ClientBounds.Height) {
                //window is wider than it is high (aspectRatio >= 1), therefore set Y axis to 200
                Axes = new Point((int)(200 * aspectRatio), 200);
            } else {
                //window is higher than it is wide (aspectRatio < 1), therefore set X axis to 200
                Axes = new Point(200, (int)(200 * 1 / aspectRatio));
            }
        }

        public bool Contains(Zone z) {
            Zone wc = z.WindowCoordinates;
            return (wc.Right > 0
                || wc.Left < Global.Window.ClientBounds.Width
                || wc.Top > 0
                || wc.Bottom < Global.Window.ClientBounds.Height);
        }
    }
}
