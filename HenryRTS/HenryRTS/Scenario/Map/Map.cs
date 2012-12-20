using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Map {

        //a map has a type (what kind of planet are we on?)
        public enum EnvironmentType {
            Earth,
            Desert,
            Ice,
            Lava,
            Asteroid
        }
        protected EnvironmentType mapType;
        public EnvironmentType MapType {
            get { return mapType; }
        }
        //a map has a name
        protected string name;
        public string Name {
            get { return name; }
        }
        //map has a size
        protected Point dimensions;
        public Point Dimensions {
            get { return dimensions; }
        }
        //map has an array of MapObjects (for easy reference/pathing)
        private MapTile[,] objectArray;
        public MapObject this[int x, int y] {
            get {
                x /= tileSize.X;
                y /= tileSize.Y;
                try {
                    return objectArray[x, y].Object;
                } catch (IndexOutOfRangeException) {
                    return null;
                }
                
            }
            set {
                x /= tileSize.X;
                y /= tileSize.Y;
                if (x < 0 || x + value.Width >= dimensions.X || y < 0 || y + value.Height >= dimensions.Y) {
                    //object is out of bounds, don't add it
                } else if (value is EmptySpace) {
                    //clear the area
                    for (int i = 0; i < value.Width; i += tileSize.X)
                        for (int j = 0; j < value.Height; j += tileSize.Y)
                            objectArray[x + i / tileSize.X, y + j / tileSize.Y].Object = null;
                } else {
                    //add this MapObject
                    for (int i = 0; i < value.Width; i += tileSize.X)
                        for (int j = 0; j < value.Height; j += tileSize.Y)
                            objectArray[x + i / tileSize.X, y + j / tileSize.Y].Object = value;
                }
            }
        }
        //it also has a list of MapObjects (for easier iteration)
        private List<MapObject> objectList;
        //map locations are partitioned into 'tiles' of a certain fixed size
        protected readonly Point tileSize = new Point(8, 8);
        //a sprite for coloring in maptiles (diagnostic)
        Sprite pixel = new Sprite("WhitePixel");

        //constructor
        public Map(Point dimensions, string name, EnvironmentType e) {
            this.dimensions = dimensions/tileSize;
            objectArray = new MapTile[Dimensions.X, Dimensions.Y];
            for (int i = 0; i < Dimensions.X; i++)
                for (int j = 0; j < Dimensions.Y; j++)
                    objectArray[i, j] = new MapTile(new Point(i, j));
            objectList = new List<MapObject>();
            this.name = name;
            this.mapType = e;
        }

        public void Update() {
            foreach (MapObject mo in objectList)
                mo.Update();
        }

        public void Draw() {
            //foreach (MapTile mt in ThingiesToDraw) {
            //    pixel.Draw(new Zone(mt.Coords.X * tileSize.X, mt.Coords.Y * tileSize.Y, 8, 8));
            //}
            foreach (MapTile mt in objectArray) {
                if (mt.Object != null)
                    pixel.Draw(new Zone(mt.Coords.X * tileSize.X, mt.Coords.Y * tileSize.Y, tileSize.X, tileSize.Y));
            }
            foreach (MapObject mo in objectList)
                mo.Draw();
        }

        public void AddObject(MapObject mo) {
            objectList.Add(mo);
        }

        //////////////////////////////////////////////////////////
        //\\\\\\  \\\\\\  \\\\\\  \\  \\  \\\\\\  \\\\     \\\\ //
        //\\  \\  \\  \\    \\    \\  \\    \\    \\  \\  \\    //
        //\\\\\\  \\\\\\    \\    \\\\\\    \\    \\  \\  \\ \\\//
        //\\      \\  \\    \\    \\  \\    \\    \\  \\  \\  \\//
        //\\      \\  \\    \\    \\  \\  \\\\\\  \\  \\  \\\\\\//
        //////////////////////////////////////////////////////////
        //List<MapTile> ThingiesToDraw = new List<MapTile>();
        Dictionary<MapTile, MapTile> cameFrom = new Dictionary<MapTile, MapTile>();
        MapTile goal, start;
        public Stack<Point> GetPath(Point start, Point goal) {
            cameFrom.Clear();
            //ThingiesToDraw.Clear();
            this.start = objectArray[start.X/tileSize.X, start.Y/tileSize.Y];
            this.goal = objectArray[goal.X/tileSize.X, goal.Y/tileSize.Y];
            SortedSet<MapTile> openSet = new SortedSet<MapTile>(new MapTileComparer());
            List<MapTile> closedSet = new List<MapTile>();

            this.start.FScore = g(this.start.Coords) + h(this.start.Coords);
            openSet.Add(this.start);
            while (openSet.Min != this.goal) {
                MapTile current = openSet.Min;
                openSet.Remove(current);
                closedSet.Add(current);
                //ThingiesToDraw.Add(current);
                foreach (MapTile neighbor in GetNeighbors(current)) {
                    float cost = g(current.Coords) + movementCost(current.Coords, neighbor.Coords);
                    if (openSet.Contains(neighbor) && cost < g(neighbor.Coords))
                        openSet.Remove(neighbor);
                    if (closedSet.Contains(neighbor) && cost < g(neighbor.Coords))
                        closedSet.Remove(neighbor);
                    if (!openSet.Contains(neighbor) && !closedSet.Contains(neighbor)) {
                        neighbor.FScore = g(neighbor.Coords) + h(neighbor.Coords);
                        if (!cameFrom.ContainsKey(neighbor))
                            cameFrom.Add(neighbor, current);
                        else
                            cameFrom[neighbor] = current;
                        openSet.Add(neighbor);
                    }
                }
            }
            return reconstructPath();
        }

        Stack<Point> reconstructPath() {
            Stack<Point> path = new Stack<Point>();
            MapTile current = goal;
            while (current != start) {
                path.Push(current.Coords * tileSize);
                current = cameFrom[current];
            }
            return path;
        }

        float g(Point p) {
            //distance from start to p
            return (p.Vector - start.Coords.Vector).Length();
        }
        float h(Point p) {
            //distance from p to goal
            //return (goal.Coords.Vector - p.Vector).Length();
            return Math.Abs(p.X - goal.Coords.X) + Math.Abs(p.Y - goal.Coords.Y);
        }
        float movementCost(Point a, Point b) {
            return (b.Vector - a.Vector).Length();
        }
        List<MapTile> GetNeighbors(MapTile mt) {
            List<MapTile> l = new List<MapTile>();
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    Point p = new Point(mt.Coords.X + i, mt.Coords.Y + j);
                    if ((p.X >= 0 && p.X < dimensions.X && p.Y >= 0 && p.Y < dimensions.Y) //its on the map
                        && (objectArray[p.X, p.Y].Object == null || objectArray[p.X, p.Y].Object == start.Object) //its open
                        && (!(i == 0 && j == 0))) { //its not mt
                            l.Add(objectArray[p.X, p.Y]);
                    }
                }
            }
            return l;
        }


        public class MapTile {
            public MapObject Object;
            public float FScore;
            //public MapTile CameFrom;
            public readonly Point Coords;
            public MapTile(Point coords) {
                Coords = coords;
            }
        }

        public class MapTileComparer : IComparer<MapTile> {
            public int Compare(MapTile x, MapTile y) {
 	            if (x.FScore < y.FScore)
                    return -1;
                else if (x.FScore > y.FScore)
                    return 1;
                else
                    return 0;
            }
        }
        








    }
   



}
