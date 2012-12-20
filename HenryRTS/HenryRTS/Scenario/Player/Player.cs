using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Player {
        //keep track of which units belong to me
        protected List<SelectableObject> SelectedStuff = new List<SelectableObject>();
        //keep track of which resources i have
        private int[] resources = new int[88];

        public Player() {
            for (int i = 0; i < 88; i++) {
                resources[i] = 0;
            }

            //also set starting resources here
            AddResource(26, 125);
        }

        public void AddResource(int atomicNumber, int amount) {
            resources[atomicNumber - 1] += amount;
        }
        public int GetResource(int atomicNumber) {
            return resources[atomicNumber - 1];
        }

        public virtual void Update() {

        }

        public virtual void Draw() {

        }

    }
}
