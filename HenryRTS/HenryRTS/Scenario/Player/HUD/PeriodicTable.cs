using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {

    public class PeriodicTable : BoundedObject {

        private ElementSquare[,] elements = new ElementSquare[7, 18];
        private Vector2 cornerPosition = new Vector2(200, 100);
        private Zone smallBounds = new Zone(0, 0, 100, 50);
        private Zone largeBounds = new Zone(0, 0, Global.Window.ClientBounds.Width, (int)(Global.Window.ClientBounds.Width / 2.0f));

        public PeriodicTable(Player myPlayer) {
            //set initial bounds
            Bounds.Mode = Zone.ZoneModeEnum.WindowCoordinates;
            Bounds.Left = 0;
            Bounds.Right = 200;
            Bounds.Top = 0;
            Bounds.Bottom = 100;

            //set elements
            //1st row
            elements[0, 0] = new ElementSquare(1, myPlayer);
            elements[0, 1] = new ElementSquare(0, myPlayer);
            elements[0, 2] = new ElementSquare(0, myPlayer);
            elements[0, 3] = new ElementSquare(0, myPlayer);
            elements[0, 4] = new ElementSquare(0, myPlayer);
            elements[0, 5] = new ElementSquare(0, myPlayer);
            elements[0, 6] = new ElementSquare(0, myPlayer);
            elements[0, 7] = new ElementSquare(0, myPlayer);
            elements[0, 8] = new ElementSquare(0, myPlayer);
            elements[0, 9] = new ElementSquare(0, myPlayer);
            elements[0, 10] = new ElementSquare(0, myPlayer);
            elements[0, 11] = new ElementSquare(0, myPlayer);
            elements[0, 12] = new ElementSquare(0, myPlayer);
            elements[0, 13] = new ElementSquare(0, myPlayer);
            elements[0, 14] = new ElementSquare(0, myPlayer);
            elements[0, 15] = new ElementSquare(0, myPlayer);
            elements[0, 16] = new ElementSquare(0, myPlayer);
            elements[0, 17] = new ElementSquare(2, myPlayer);
            //2nd row
            elements[1, 0] = new ElementSquare(3, myPlayer);
            elements[1, 1] = new ElementSquare(4, myPlayer);
            elements[1, 2] = new ElementSquare(0, myPlayer);
            elements[1, 3] = new ElementSquare(0, myPlayer);
            elements[1, 4] = new ElementSquare(0, myPlayer);
            elements[1, 5] = new ElementSquare(0, myPlayer);
            elements[1, 6] = new ElementSquare(0, myPlayer);
            elements[1, 7] = new ElementSquare(0, myPlayer);
            elements[1, 8] = new ElementSquare(0, myPlayer);
            elements[1, 9] = new ElementSquare(0, myPlayer);
            elements[1, 10] = new ElementSquare(0, myPlayer);
            elements[1, 11] = new ElementSquare(0, myPlayer);
            elements[1, 12] = new ElementSquare(5, myPlayer);
            elements[1, 13] = new ElementSquare(6, myPlayer);
            elements[1, 14] = new ElementSquare(7, myPlayer);
            elements[1, 15] = new ElementSquare(8, myPlayer);
            elements[1, 16] = new ElementSquare(9, myPlayer);
            elements[1, 17] = new ElementSquare(10, myPlayer);
            //3rd row
            elements[2, 0] = new ElementSquare(11, myPlayer);
            elements[2, 1] = new ElementSquare(12, myPlayer);
            elements[2, 2] = new ElementSquare(0, myPlayer);
            elements[2, 3] = new ElementSquare(0, myPlayer);
            elements[2, 4] = new ElementSquare(0, myPlayer);
            elements[2, 5] = new ElementSquare(0, myPlayer);
            elements[2, 6] = new ElementSquare(0, myPlayer);
            elements[2, 7] = new ElementSquare(0, myPlayer);
            elements[2, 8] = new ElementSquare(0, myPlayer);
            elements[2, 9] = new ElementSquare(0, myPlayer);
            elements[2, 10] = new ElementSquare(0, myPlayer);
            elements[2, 11] = new ElementSquare(0, myPlayer);
            elements[2, 12] = new ElementSquare(13, myPlayer);
            elements[2, 13] = new ElementSquare(14, myPlayer);
            elements[2, 14] = new ElementSquare(15, myPlayer);
            elements[2, 15] = new ElementSquare(16, myPlayer);
            elements[2, 16] = new ElementSquare(17, myPlayer);
            elements[2, 17] = new ElementSquare(18, myPlayer);
            
            for (int i = 0; i < 18; i++) {
                //4th row
                elements[3, i] = new ElementSquare(19 + i, myPlayer);
                //5th row
                elements[4, i] = new ElementSquare(37 + i, myPlayer);
            }

            //6th row
            elements[5, 0] = new ElementSquare(55, myPlayer);
            elements[5, 1] = new ElementSquare(56, myPlayer);
            elements[5, 2] = new ElementSquare(0, myPlayer);
            elements[5, 3] = new ElementSquare(72, myPlayer);
            elements[5, 4] = new ElementSquare(73, myPlayer);
            elements[5, 5] = new ElementSquare(74, myPlayer);
            elements[5, 6] = new ElementSquare(75, myPlayer);
            elements[5, 7] = new ElementSquare(76, myPlayer);
            elements[5, 8] = new ElementSquare(77, myPlayer);
            elements[5, 9] = new ElementSquare(78, myPlayer);
            elements[5, 10] = new ElementSquare(79, myPlayer);
            elements[5, 11] = new ElementSquare(80, myPlayer);
            elements[5, 12] = new ElementSquare(81, myPlayer);
            elements[5, 13] = new ElementSquare(82, myPlayer);
            elements[5, 14] = new ElementSquare(83, myPlayer);
            elements[5, 15] = new ElementSquare(84, myPlayer);
            elements[5, 16] = new ElementSquare(85, myPlayer);
            elements[5, 17] = new ElementSquare(86, myPlayer);
            //7th row (last!)
            elements[6, 0] = new ElementSquare(87, myPlayer);
            elements[6, 1] = new ElementSquare(88, myPlayer);
            elements[6, 2] = new ElementSquare(0, myPlayer);
            elements[6, 3] = new ElementSquare(0, myPlayer);
            elements[6, 4] = new ElementSquare(0, myPlayer);
            elements[6, 5] = new ElementSquare(0, myPlayer);
            elements[6, 6] = new ElementSquare(0, myPlayer);
            elements[6, 7] = new ElementSquare(0, myPlayer);
            elements[6, 8] = new ElementSquare(0, myPlayer);
            elements[6, 9] = new ElementSquare(0, myPlayer);
            elements[6, 10] = new ElementSquare(0, myPlayer);
            elements[6, 11] = new ElementSquare(0, myPlayer);
            elements[6, 12] = new ElementSquare(0, myPlayer);
            elements[6, 13] = new ElementSquare(0, myPlayer);
            elements[6, 14] = new ElementSquare(0, myPlayer);
            elements[6, 15] = new ElementSquare(0, myPlayer);
            elements[6, 16] = new ElementSquare(0, myPlayer);
            elements[6, 17] = new ElementSquare(0, myPlayer);
        }

        public override void Update() {
            //calculate lower left corner position
            if (this.smallBounds.Contains(Mouse.PositionInWindow))
                cornerPosition = Global.MoveElastically(cornerPosition, 10.0f, new Vector2(largeBounds.Right, largeBounds.Bottom));
            else
                cornerPosition = Global.MoveElastically(cornerPosition, 10.0f, new Vector2(smallBounds.Right, smallBounds.Bottom));
            Bounds.Right = (int)cornerPosition.X;
            Bounds.Bottom = (int)cornerPosition.Y;

            //set the bounds of my squares
            for (int i = 0; i < 7; i++) {
                for (int j = 0; j < 18; j++) {
                    elements[i, j].Bounds.Width = (int)((float)Bounds.Width / (float)18);
                    elements[i, j].Bounds.Height = Bounds.Height / 7;
                    elements[i, j].Bounds.Center = new Point(
                        Bounds.Width / 18 * j,
                        Bounds.Height / 7 * i)
                        + new Point(Bounds.Width / 18 / 2, Bounds.Height / 7 / 2);
                    elements[i, j].Update();
                }
            }
            
        }

        public override void Draw() {
            //draw a border|background?
            for (int i = 0; i < 7; i++) {
                for (int j = 0; j < 18; j++) {
                    elements[i, j].Draw();
                }
            }
        }
    }

    public class ElementSquare : BoundedObject {

        bool isEmpty = false;
        int atomicNumber;
        Player myPlayer;
        Sprite pixel = new Sprite("WhitePixel");
        Sprite background = new Sprite("WhitePixel");
        TextSprite symbol = new TextSprite(), quantity = new TextSprite();
        
        public ElementSquare(int atomicNumber, Player myPlayer) {
            Bounds.Mode = Zone.ZoneModeEnum.WindowCoordinates;
            if (atomicNumber == 0)
                //this is an empty tile on the table
                isEmpty = true;
            else {
                this.myPlayer = myPlayer;
                this.atomicNumber = atomicNumber;
                background.Color = Elements.GetElement(atomicNumber).Color;
                pixel.Color = Color.Black;

                symbol.Font = Fonts.Consolas;
                symbol.Text = Elements.GetElement(atomicNumber).Symbol;
                symbol.Color = Color.Black;
                symbol.Origin = Global.Origins.Left;

                quantity.Font = Fonts.Consolas;
                quantity.Text = "0";
                quantity.Color = Color.Black;
                quantity.Origin = Global.Origins.BottomRight;
            }
        }

        public override void Update() {
            if (isEmpty) return;

            quantity.Text = myPlayer.GetResource(atomicNumber).ToString();
            symbol.Position = new Point(Bounds.Left, Bounds.Center.Y);
            quantity.Position = new Point(Bounds.Right, Bounds.Bottom);
            //scaling
            symbol.Scale = Bounds.Height / symbol.Font.MeasureString(symbol.Text).Y / 3;
            quantity.Scale = Bounds.Height / symbol.Font.MeasureString(symbol.Text).Y / 4;
        }

        public override void Draw() {
            if (isEmpty) return;

            background.Draw(Bounds);

            //draw lines around square
            Zone z = new Zone(Zone.ZoneModeEnum.WindowCoordinates, 0, 0, 0, 0);
            z.Center = Bounds.Center;
            //right line
            z.Right = Bounds.Right;
            z.Left = Bounds.Right - 1;
            z.Top = Bounds.Top;
            z.Bottom = Bounds.Bottom;
            pixel.Draw(z);
            //bottom line
            z.Left = Bounds.Left;
            z.Top = Bounds.Bottom - 1;
            pixel.Draw(z);

            symbol.Draw();
            quantity.Draw();
        }

    }

}
