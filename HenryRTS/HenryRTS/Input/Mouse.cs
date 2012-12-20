using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HenryRTS {

    public class Mouse {
        private Sprite cursor = new Sprite();
        private Sprite pixel = new Sprite();
        public enum CursorTypeEnum {
            Point,
            Select,
            Attack
        }
        private Point position = new Point(0, 0);
        private MouseState ms, pms;
        public Zone SelectionBox = new Zone(Zone.ZoneModeEnum.WindowCoordinates, 0, 0, 0, 0);
        private Point DragStart = new Point(0, 0);

        public enum MouseButton {
            None, Left, Right, Middle
        }
        private MouseButton buttonIsDown = MouseButton.None;
        public MouseButton ButtonIsDown {
            get { return buttonIsDown; }
        }
        public Point PositionInWindow {
            get { return position; }
        }
        public Point PositionInGame {
            get { return position + Global.Camera.TopLeftCorner; }
        }
        private bool isDragging = false;
        public bool IsDragging {
            get { return isDragging; }
        }






        public Mouse() {
            cursor.SpriteName = "CursorMenu";
            pixel.SpriteName = "WhitePixel";
            cursor.Bounds.Mode = Zone.ZoneModeEnum.WindowCoordinates;
            cursor.Bounds.LockDimensions = true;
        }

        public void Update() {
            pms = ms;
            ms = Microsoft.Xna.Framework.Input.Mouse.GetState();
            //check buttons
            if (ms.LeftButton == ButtonState.Pressed)
                buttonIsDown = MouseButton.Left;
            else if (ms.RightButton == ButtonState.Pressed)
                buttonIsDown = MouseButton.Right;
            else if (ms.MiddleButton == ButtonState.Pressed)
                buttonIsDown = MouseButton.Middle;
            else
                buttonIsDown = MouseButton.None;
            //update position
            position = new Point(ms.X, ms.Y);
            cursor.Bounds.Left = position.X;
            cursor.Bounds.Top = position.Y;

            //determine if user is dragging the mouse
            bool wasDragging = isDragging;
            isDragging = ms.LeftButton == ButtonState.Pressed && (wasDragging || (new Vector2(pms.X, pms.Y) - new Vector2(ms.X, ms.Y)).Length() > 3);
            if (!wasDragging && isDragging) {
                //user has just started a drag motion
                DragStart = new Point(pms.X, pms.Y);
            } else if (wasDragging && !isDragging) {
                //user has just finished a drag motion
                DragStart = new Point(ms.X, ms.Y);
            } else if (!wasDragging && !isDragging) {
                //user is not dragging at all
                DragStart = new Point(ms.X, ms.Y);
            } else if (wasDragging && isDragging) {
                //user is totally dragging
                
            }
            
            //check to see which direction the user is dragging the mouse
            Point DragEnd = new Point(ms.X, ms.Y);
            if (DragStart.X <= DragEnd.X && DragStart.Y <= DragEnd.Y) { //user is dragging down and to the right
                SelectionBox.Left = DragStart.X;
                SelectionBox.Top = DragStart.Y;
                SelectionBox.Right = DragEnd.X;
                SelectionBox.Bottom = DragEnd.Y;
            } else if (DragStart.X > DragEnd.X && DragStart.Y <= DragEnd.Y) { //user is dragging down and to the left
                SelectionBox.Left = DragEnd.X;
                SelectionBox.Top = DragStart.Y;
                SelectionBox.Right = DragStart.X;
                SelectionBox.Bottom = DragEnd.Y;
            } else if (DragStart.X <= DragEnd.X && DragStart.Y > DragEnd.Y) { //user is dragging up and to the right
                SelectionBox.Left = DragStart.X;
                SelectionBox.Top = DragEnd.Y;
                SelectionBox.Right = DragEnd.X;
                SelectionBox.Bottom = DragStart.Y;
            } else if (DragStart.X > DragEnd.X && DragStart.Y > DragEnd.Y) { //user is dragging up and to the left
                SelectionBox.Left = DragEnd.X;
                SelectionBox.Top = DragEnd.Y;
                SelectionBox.Right = DragStart.X;
                SelectionBox.Bottom = DragStart.Y;
            }        

        }

        public void Draw() {
            cursor.Draw();
            pixel.Color = Color.ForestGreen;
            pixel.Color.A = 1;
            pixel.Draw(SelectionBox);

            pixel.Color = Color.White;
            //draw four lines by stretching pixel
            Zone z = new Zone(Zone.ZoneModeEnum.WindowCoordinates, 0, 0, 0, 0);
            //top line
            z.Left = SelectionBox.Left;
            z.Right = SelectionBox.Right;
            z.Top = SelectionBox.Top;
            z.Bottom = SelectionBox.Top + 1;
            pixel.Draw(z);
            //bottom line
            z.Bottom = SelectionBox.Bottom;
            z.Top = SelectionBox.Bottom - 1;
            pixel.Draw(z);
            //left line
            z.Right = SelectionBox.Left + 1;
            z.Top = SelectionBox.Top;
            pixel.Draw(z);
            //right line
            z.Right = SelectionBox.Right;
            z.Left = SelectionBox.Right - 1;
            pixel.Draw(z);
            
        }

    }
}