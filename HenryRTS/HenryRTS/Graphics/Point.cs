using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Point {
        //data
        public int X, Y;

        //constructor
        public Point(int x, int y) {
            X = x;
            Y = y;
        }
        public Point(Vector2 v) {
            X = (int)v.X;
            Y = (int)v.Y;
        }

        //accessors
        public Vector2 Vector {
            get { return new Vector2(X, Y); }
        }

        //logical comparison operators
        public static bool operator ==(Point a, Point b) {
            return (a.X == b.X && a.Y == b.Y);
        }
        public static bool operator !=(Point a, Point b) {
            return (a.X != b.X && a.Y != b.Y);
        }

        //Point to Point math operators
        public static Point operator +(Point a, Point b) {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point operator -(Point a, Point b) {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        public static Point operator *(Point a, Point b) {
            return new Point(a.X * b.X, a.Y * b.Y);
        }
        public static Point operator /(Point a, Point b) {
            return new Point(a.X / b.X, a.Y / b.Y);
        }

        //float to Point math operators
        public static Point operator +(float f, Point p) {
            return new Point((int)(f + p.X), (int)(f + p.Y));
        }
        public static Point operator -(float f, Point p) {
            return new Point((int)(f - p.X), (int)(f - p.Y));
        }
        public static Point operator *(float f, Point p) {
            return new Point((int)(f * p.X), (int)(f * p.Y));
        }
        public static Point operator /(float f, Point p) {
            return new Point((int)(f / p.X), (int)(f / p.Y));
        }
        
        //other
        public override bool Equals(object obj) {
            return this == (Point)obj;
        }
        public override string ToString() {
            return "{X:" + X + " Y:" + Y + "}";
        }
    }
}
