using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {

    public class Zone {

        //data
        private int left, right, top, bottom;
        public enum ZoneModeEnum {
            WindowCoordinates,
            GameCoordinates
        };
        public ZoneModeEnum Mode;
        public bool LockDimensions = false;

        //constructors
        public Zone() {
            left = 0; right = 0; top = 0; bottom = 0;
            Mode = ZoneModeEnum.GameCoordinates;
        }
        public Zone(int left, int top, int width, int height) {
            this.left = left;
            this.top = top;
            this.right = left + width;
            this.bottom = top + height;
            Mode = ZoneModeEnum.GameCoordinates;
        }
        public Zone(ZoneModeEnum mode) {
            left = 0; right = 0; top = 0; bottom = 0;
            Mode = mode;
        }
        public Zone(ZoneModeEnum mode, int left, int top, int width, int height) {
            this.left = left;
            this.top = top;
            this.right = left + width;
            this.bottom = top + height;
            Mode = mode;
        }

        //accessors
        public Rectangle Rectangle {
            get { return new Rectangle(left, top, right - left, bottom - top); }
        }
        public int Width {
            get { return right - left; }
            set {
                if (value >= 0)
                    right = left + value;
            }
        }
        public int Height {
            get { return bottom - top; }
            set {
                if (value >= 0)
                    bottom = top + value;
            }
        }
        public int Left {
            get { return left; }
            set {
                if (LockDimensions)
                    right += value - left;
                left = value;
            }
        }
        public int Right {
            get { return right; }
            set {
                if (LockDimensions)
                    left += value - right;
                right = value;
            }
        }
        public int Top {
            get { return top; }
            set {
                if (LockDimensions)
                    bottom += value - top;
                top = value;
            }
        }
        public int Bottom {
            get { return bottom; }
            set {
                if (LockDimensions)
                    top += value - bottom;
                bottom = value;
            }
        }
        public Point Center {
            //setting the center of the zone shifts the whole zone
            get { return new Point(left + (right-left)/2, top + (bottom-top)/2); }
            set {
                Point diff = value - Center;
                left += diff.X;
                right += diff.X;
                top += diff.Y;
                bottom += diff.Y;
            }
        }
        public Zone WindowCoordinates {
            get {
                if (this.Mode == ZoneModeEnum.WindowCoordinates)
                    return (Zone)this.MemberwiseClone();
                else {
                    Zone wc = (Zone)this.MemberwiseClone();
                    wc.Mode = ZoneModeEnum.WindowCoordinates;
                    wc.Center -= Global.Camera.TopLeftCorner;
                    return wc;
                }
            }
        }
        public Zone GameCoordinates {
            get {
                if (this.Mode == ZoneModeEnum.GameCoordinates)
                    return (Zone)this.MemberwiseClone();
                else {
                    Zone wc = (Zone)this.MemberwiseClone();
                    wc.Mode = ZoneModeEnum.GameCoordinates;
                    wc.Center += Global.Camera.TopLeftCorner;
                    return wc;
                }
            }
        }

        //other
        public void Diag() {
            Console.Write("+---" + Rectangle.Top + "---+\n");
            Console.Write("|   " + "   " + "   |\n");
            Console.Write(Rectangle.Left + "     " + Rectangle.Right + "\n");
            Console.Write("|   " + "   " + "   |\n");
            Console.Write("+---" + Rectangle.Bottom + "---+\n");
        }
        public bool Contains(Zone z) {
            if (this.Mode != z.Mode)
                throw new Exception("Attempted to compare zones of differing coordinate modes.");
            else {
                return (this.Left <= z.Left
                    && this.Right >= z.Right
                    && this.Top <= z.Top
                    && this.Bottom >= z.Bottom);
            }
        }
        public bool Contains(Point p) {
            return (this.Left <= p.X
                && this.Right >= p.X
                && this.Top <= p.Y
                && this.Bottom >= p.Y);
        }
        public void DrawBorder() {
                Zone z = new Zone();
                z.Center = Center;
                //top line
                z.Left = Left - 1;
                z.Top = Top - 1;
                z.Right = Right;
                z.Bottom = Top;
                Utility.DrawPixel(z, Color.Tomato);
                //right line
                z.Right = Right + 1;
                z.Left = Right;
                z.Bottom = Bottom;
                Utility.DrawPixel(z, Color.Tomato);
                //bottom line
                z.Bottom = Bottom + 1;
                z.Top = Bottom;
                z.Left = Left;
                Utility.DrawPixel(z, Color.Tomato);
                //left line
                z.Left = Left - 1;
                z.Right = Left;
                z.Top = Top;
                Utility.DrawPixel(z, Color.Tomato);
        }
    }
}
