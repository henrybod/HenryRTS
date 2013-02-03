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
        private Sprite selectionCircle;

        public HumanPlayer(Color color) : base(color) {
            healthBar = new ProgressBar(new Zone(0, 0, 10, 2));
            healthBar.BorderThickness = 0;
            resourceBar = new ResourceBar(new Zone(0, 0, 40, 6));
            resourceBar.BorderThickness = 0;
            pt = new PeriodicTable(this);
            selectionCircle = new Animation("SelectionCircleSmall");
        }


        public override void Update() {
            //accept input from the user
            if (Mouse.ButtonIsDown == Mouse.MouseButton.None) {
                //lets just not do anything for the moment, but eventually could have a highlighting mechanism

            } else if (Mouse.ButtonIsDown == Mouse.MouseButton.Left) {
                //we're selecting stuff, either one thing (click) or a group of things (drag)
                if (Mouse.IsDragging) {
                    //user is draggin' a selection box
                    //todo:!!! get all map objects within the box
                } else {
                    //user is clicking in one place
                    if (!Keyboard.Shift)
                        SelectedStuff.Clear();
                    MapObject mo = Scenario.Map[Mouse.PositionInGame.X, Mouse.PositionInGame.Y];
                    if (mo == null || mo is Location) {
                        //do nothing
                    } else if (mo is SelectableObject)
                        SelectedStuff.Add((SelectableObject)mo);
                    //any other possibilities?
                }

            } else if (Mouse.ButtonIsDown == Mouse.MouseButton.Right && SelectedStuff.Count > 0) {
                //we're giving orders to selected units
                MapObject target = Scenario.Map[Mouse.PositionInGame.X, Mouse.PositionInGame.Y];
                foreach (SelectableObject so in SelectedStuff) {
                    if (so is ControllableObject) {
                        if (((ControllableObject)so).Owner == this) {
                            if (target == null) {
                                //a null target means there's nothing there
                                if (so is Unit) {
                                    ((Unit)so).SetTask(new MoveTask(Mouse.PositionInGame));
                                } else if (so is Building) {
                                    //set this building's waypoint to the mouse's position
                                }
                            } else if (target is SelectableObject) {
                                //the user has clicked on some object that my so can handle
                                if (target is ControllableObject) {
                                    //its either a friendly unit
                                    if (((ControllableObject)target).Owner == this) {
                                        //set to follow
                                        if (so is Unit) { //tell unit to follow
                                            ((Unit)so).SetTask(new FollowTask((ControllableObject)target));
                                        } else if (so is Building) { //set building waypoint to that unit
                                            ((Building)so).SetTask(new FollowTask((ControllableObject)target));
                                        }
                                    //or an enemy unit
                                    } else { //todo: set up logic for allied units
                                        if (so is Unit) { //tell unit to attack
                                            ((Unit)so).SetTask(new AttackTask((ControllableObject)target));
                                        } else if (so is Building) { //tell building to attack (if applicable)
                                            ((Building)so).SetTask(new AttackTask((ControllableObject)target));
                                        }
                                    }
                                    

                                } else if (target is Resource) {
                                    if (so is Unit) {
                                        ((Unit)so).SetTask(new MineTask((Resource)target));
                                    }
                                }
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
                //draw selection circle
                //set to owner color
                selectionCircle.Bounds.Center = new Point(io.Center.X, io.Bottom);
                selectionCircle.Color = this.Color;
                selectionCircle.Draw();

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