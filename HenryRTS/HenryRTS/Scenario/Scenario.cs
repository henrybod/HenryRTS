using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Scenario : Screen {
        //this is a new game
        //are we having fun yet?

        //this class is a "Singleton"
        //that is, it acts somewhat statically
        //but has a single instance of it
        private static Scenario instance;
        public static Scenario Instance {
            get { return instance; } //this should only be used to feed the CurrentScreen
        }

        //a scenario has players, a map, and maybe a scoreboard or something
        private Map map;
        public static Map Map {
            get {
                if (instance == null)
                    throw new Exception("Error: Attempted to access map, but scenario not started.");
                return instance.map;
            }
        }

        private List<Player> players;
        public List<Player> Players {
            get {
                if (instance == null)
                    throw new Exception("Error: Attempted to access a player, but scenario not started.");
                return instance.players;
            }
        }
        //todo: make scoreboard | game summary thingy


        //SETTINGS//
        //herein lie all of the possible configuration variables for a scenario (and their defaults)
        //these may all be set by clicking various buttons in the New Scenario menu
        public static int NumberOfPlayers = 2;
        public static Global.MapEnvironments MapType = Global.MapEnvironments.Earth;
        public static Global.GenericSizes MapSize = Global.GenericSizes.Small;
        public static Global.GenericSizes StartingResources = Global.GenericSizes.Medium;
        public static bool FogOfWar = true;
        public static float GlobalBuildSpeedModifier = 1.0f;
        public static float GlobalBuildCostModifier = 1.0f;
        public static int CeaseFireSeconds = 0;
        //moar to come!






        public Scenario() {
            
            //set up Screen stuff
            Bounds = new Zone(0, 0, 2048, 2048);   
            background.SpriteName = "Dirt";
            background.Bounds = new Zone(0, 0, 2048, 2048);

            //set up Map (based on configuration variables above)
            map = new RandomMap(new Point(2048, 2048), MapType);
            players = new List<Player>();
            
            instance = this;

            ((RandomMap)map).Populate();
            players.Add(new HumanPlayer(Color.Red));
            
            new Gatherer(Players[0], new Point(400, 400));
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
