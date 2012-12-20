using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Button : BoundedObject {

        //default size for any button
        public static readonly Point DefaultButtonSize = new Point(100, 50);
        public delegate void ButtonAction();
        public ButtonAction OnClick = new ButtonAction(()=>{}); //default action: do nothing
        private enum ButtonState {
            Disabled,
            Idle,
            Highlighted,
            Pressed
        }
        private ButtonState currState = ButtonState.Idle, prevState = ButtonState.Idle;
        private TextSprite text;
        public string Text {
            get { return text.Text; }
            set { text.Text = value; }
        }
        private Animation Idle = new Animation("ButtonDefaultIdle");
        private Animation Highlighted = new Animation("ButtonDefaultHighlighted");
        private Animation Pressed = new Animation("ButtonDefaultPressed");
        private Animation Disabled = new Animation("ButtonDefaultDisabled");


        public Button() : base(new Zone(0, 0, DefaultButtonSize.X, DefaultButtonSize.Y)){ 
            //set fps
            Idle.FPS = 5;
            Highlighted.FPS = 5;
            Pressed.FPS = 5;
            Disabled.FPS = 5;
            //add text to this button
            text = new TextSprite();
            text.Color = Color.Black;
            text.Origin = Global.Origins.Center;
        }

        public override void Update() {
            
            //read the mouse
            prevState = currState;
            currState = CheckButtonStatus();
            Idle.Update();
            Highlighted.Update();
            Pressed.Update();
            Disabled.Update();

            //determine if i've just been clicked
            if (prevState == ButtonState.Pressed && currState == ButtonState.Highlighted)
                OnClick();

            base.Update();
            text.Position = Bounds.Center;
        }

        public override void Draw() {
            if (currState == ButtonState.Idle)
                Idle.Draw(Bounds);
            else if (currState == ButtonState.Highlighted)
                Highlighted.Draw(Bounds);
            else if (currState == ButtonState.Pressed)
                Pressed.Draw(Bounds);
            else
                Disabled.Draw(Bounds);
            text.Draw();
        }

        private ButtonState CheckButtonStatus() {
            if (currState == ButtonState.Disabled)
                return ButtonState.Disabled;

            if (this.Bounds.Contains(Global.Mouse.PositionInGame)) {
                if (Global.Mouse.ButtonIsDown == Mouse.MouseButton.Left)
                    return ButtonState.Pressed;
                else
                    return ButtonState.Highlighted;
            } else {
                return ButtonState.Idle;
            }

        }

    }
}
