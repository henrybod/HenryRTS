using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HenryRTS {
    public class TextSprite {

        private string text = "";
        public string Text {
            get { return text; }
            set {
                if (value.Length >= 1) {
                    Origin = Origin;
                    text = value;
                }
            }
        }
        public SpriteFont Font = Fonts.Motorwerk; //default font
        public Color Color = Color.White;
        public float Scale = 1.0f;
        public Point Position = new Point(0, 0);
        private Global.Origins oEnum;
        private Vector2 origin = Vector2.Zero;
        public Global.Origins Origin {
            get { return oEnum; }
            set {
                Vector2 size = Font.MeasureString(Text);
                if (value == Global.Origins.Bottom)
                    origin = new Vector2(size.X / 2, size.Y);
                else if (value == Global.Origins.BottomLeft)
                    origin = new Vector2(0, size.Y);
                else if (value == Global.Origins.BottomRight)
                    origin = size;
                else if (value == Global.Origins.Center)
                    origin = size / 2;
                else if (value == Global.Origins.Left)
                    origin = new Vector2(0, size.Y / 2);
                else if (value == Global.Origins.Right)
                    origin = new Vector2(size.X, size.Y / 2);
                else if (value == Global.Origins.Top)
                    origin = new Vector2(size.X / 2, 0);
                else if (value == Global.Origins.TopLeft)
                    origin = new Vector2(0, 0);
                else if (value == Global.Origins.TopRight)
                    origin = new Vector2(size.X, 0);
                else
                    throw new Exception("Invalid origin value?! [TextSprite]");
                oEnum = value;
            }
        }

        public TextSprite(string s = "{Empty String}") {
            Text = s;
        }
        public TextSprite(Point position, string s = "{Empty String}") {
            Text = s;
            Position = position;
        }

        public void Update() {
            //set text to fit the bounds
            //scale = new Vector2(Bounds.Width, Bounds.Height) / Font.MeasureString(Text);
        }

        public void Draw() {
            //Utility.DrawPixel(new Zone(Position.X - (int)origin.X, Position.Y - (int)origin.Y, (int)Font.MeasureString(Text).X, (int)Font.MeasureString(Text).Y), Color.White);
            Global.SpriteBatch.DrawString(Font, Text, Position.Vector, Color, 0.0f, origin, Scale, SpriteEffects.None, 0);
        }

    }
}
