using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Player {
        //keep track of which units i have selected
        protected List<SelectableObject> SelectedStuff = new List<SelectableObject>();
        //keep track of which units i own
        protected List<ControllableObject> MyStuff = new List<ControllableObject>();
        //keep track of which resources i have
        private int[] resources = new int[88];
        //players have a color to identify them
        public readonly Color Color;

        public Player(Color color) {
            //set my color
            this.Color = color;

            //initialize resource pool
            for (int i = 0; i < 88; i++) {
                resources[i] = 0;
            }
            
            //also set starting resources here!!!
            AddResource(26, 125);
        }

        public void AddResource(int atomicNumber, int amount) {
            //todo: make enumerator for elements so that i may index via element name
            resources[atomicNumber - 1] += amount;
        }
        public int GetResource(int atomicNumber) {
            return resources[atomicNumber - 1];
        }
        public void AddObject(ControllableObject co) {
            MyStuff.Add(co);
        }
        public void RemoveObject(ControllableObject co) {
            MyStuff.Remove(co);
        }
        public ControllableObject GetNearest(Type t, Point near) {
            ControllableObject nearest = null;
            float distance = -1;
            foreach (ControllableObject co in MyStuff) {
                if (co.GetType() == t) {
                    if (distance == -1 || (co.Position - near.Vector).Length() < distance) {
                        distance = (co.Position - near.Vector).Length();
                        nearest = co;
                    }
                }
            }

            if (distance == -1)
                return null;
            else
                return nearest;
        }

        public virtual void Update() {

        }

        public virtual void Draw() {

        }

    }
}
