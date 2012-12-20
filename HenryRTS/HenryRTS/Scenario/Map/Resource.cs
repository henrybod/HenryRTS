using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Resource : SelectableObject {

        //this interactive object has resources and a resource bar
        //it may also be mined by gatherers

        //list of elements contained herein
        private int[] elements; //the index corresponds to the atomic number of the element
        public int[] Elements {
            get { return elements; }
        }

        private int totalUnits = 0;
        public int TotalUnits {
            get { return totalUnits; }
        }


        public Resource(Map m, Zone initialBounds) : base(m, initialBounds) {
            //initialize element array
            elements = new int[88];
            for (int i = 0; i < Elements.Length; i++) {
                elements[i] = 0;
            }
        }

        public void AddElement(int atomicNumber, int quantity) {
            if (atomicNumber > 0 && atomicNumber <= 88 && quantity > 0) {
                elements[atomicNumber] += quantity;
                totalUnits += quantity;
            }
        }

        public void RemoveElement(int atomicNumber, int quantity) {
            if (atomicNumber > 0 && atomicNumber <= 88 && quantity > 0) {
                elements[atomicNumber] -= quantity;
                totalUnits -= quantity;
            }
        }

    }
}
