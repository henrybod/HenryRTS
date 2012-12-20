using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Scenario : Screen {
        //this is a new game
        //are we having fun yet?
        //a scenario has players, a map, and maybe a scoreboard or something
        public Map Map;
        public List<Player> Players = new List<Player>();
        //todo: make scoreboard | game summary thingy

        public Scenario() {
            Bounds = new Zone(0, 0, 2048, 2048);   
            background.SpriteName = "Dirt";
            background.Bounds = new Zone(0, 0, 2048, 2048);
            Map = new RandomMap(new Point(2048, 2048), Map.EnvironmentType.Earth);
            Players.Add(new HumanPlayer(this));

            new Gatherer(Players[0], Map, new Point(400, 400));
            new BigAssWall(Players[0], Map, new Point(500, 20));
        }


        public override void Update() {
            base.Update();
            foreach (Player p in Players)
                p.Update();
            Map.Update();
        }

        public override void Draw() {
            base.Draw(); //draw background image
            Map.Draw(); //draw map objects
            foreach (HumanPlayer p in Players)
                p.Draw(); //draw player interface
        }
    }
}
