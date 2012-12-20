using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class MainMenu : Menu {

        public MainMenu() {
            Button b = new Button();
            b.Bounds.Center = new Point(200, 100);
            b.Text = "New Game";
            b.OnClick = new Button.ButtonAction(() => {
                //this button creates a new scenario (for now)
                //eventually, this button will link to an options menu for the scenario
                //tv-show picard, let's call him larry,
                   //      //     //////    //////   //   //
                  //      ///    //  //    //  //    // //
                 //      ////   //////    //////     //
                //////  // //  //    //  //   //    //
                Global.CurrentScreen = new Scenario();

            });
            Buttons.Add(b);
            
        }
    }
}
