using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class HumanPlayer : Player {

        private ProgressBar healthBar;
        private ResourceBar resourceBar;
        private PeriodicTable pt;
        private Scenario myScenario;

        public HumanPlayer(Scenario s) {
            healthBar = new ProgressBar(new Zone(0, 0, 10, 2));
            healthBar.BorderThickness = 0;
            resourceBar = new ResourceBar(new Zone(0, 0, 40, 6));
            resourceBar.BorderThickness = 0;
            pt = new PeriodicTable(this);
            myScenario = s;
        }


        public override void Update() {
            //accept input from the user
            if (Global.Mouse.ButtonIsDown == Mouse.MouseButton.None) {
                //lets just not do anything for the moment, but eventually could have a highlighting mechanism

            } else if (Global.Mouse.ButtonIsDown == Mouse.MouseButton.Left) {
                //we're selecting stuff, either one thing (click) or a group of things (drag)
                if (Global.Mouse.IsDragging) {
                    //user is draggin' a selection box
                    //todo:!!! get all map objects within the box
                } else {
                    //user is clicking in one place
                    if (!Global.Keyboard.Shift)
                        SelectedStuff.Clear();
                    MapObject mo = myScenario.Map[Global.Mouse.PositionInGame.X, Global.Mouse.PositionInGame.Y];
                    if (mo == null || mo is Location) {
                        //do nothing
                    } else if (mo is SelectableObject)
                        SelectedStuff.Add((SelectableObject)mo);
                    //any other possibilities?
                }

            } else if (Global.Mouse.ButtonIsDown == Mouse.MouseButton.Right) {
                //we're giving orders to selected units
                MapObject target = myScenario.Map[Global.Mouse.PositionInGame.X, Global.Mouse.PositionInGame.Y];
                foreach (SelectableObject io in SelectedStuff) {
                    if (io is ControllableObject) {
                        if (((ControllableObject)io).Owner == this) {
                            if (target == null) {
                                //a null target means there's nothing there
                                if (io is Unit) {
                                    ((Unit)io).MoveTo(Global.Mouse.PositionInGame);
                                } else if (io is Building) {
                                    //set this building's waypoint to the mouse's position
                                }
                            } else if (target is SelectableObject) {
                                //the user has clicked on some object that my io can handle
                                ((ControllableObject)io).Target = target;
                            }
                        }
                    }
                }

            }

            pt.Update();
        }

        public override void Draw() {
            
            //draw selection related stuff
            foreach (SelectableObject io in SelectedStuff) {
                if (io is Unit) {
                    healthBar.Bounds.Width = io.Width;
                    healthBar.Bounds.Center = new Point(io.Center.X, io.Bottom);
                    healthBar.FactorFull = (float)((Unit)io).Health / (float)((Unit)io).HealthMax;
                    healthBar.Draw();
                } else if (io is Building) {
                    healthBar.Bounds.Center = new Point(io.Center.X, io.Bottom);
                    healthBar.FactorFull = (float)((Building)io).Health / (float)((Building)io).HealthMax;
                    healthBar.Draw();
                    //todo: add progress bar for construction
                } else if (io is Resource) {
                    resourceBar.Bounds.Center = new Point(io.Center.X, io.Bottom);
                    resourceBar.Draw((Resource)io);
                }
                
            }

            pt.Draw();
        }




        
    }
}