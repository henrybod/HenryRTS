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
        protected Animation Idle, BeingMined, Consumed;
        public enum ResourceStates {
            Idle,
            BeingMined,
            Consumed
        }
        private ResourceStates resourceState = ResourceStates.Idle;

        public Resource(Zone initialBounds) : base(initialBounds) {
            //initialize element array
            elements = new int[88];
            for (int i = 0; i < Elements.Length; i++) {
                elements[i] = 0;
            }
            //initialize sprites
            Idle = new Animation("WhitePixel");
            BeingMined = new Animation("WhitePixel");
            Consumed = new Animation("WhitePixel");
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

        public override void Update() {
            DetermineState();
            if (resourceState == ResourceStates.Idle)
                Play(Idle);
            else if (resourceState == ResourceStates.BeingMined)
                Play(BeingMined);
            else if (resourceState == ResourceStates.Consumed)
                Play(Consumed);
            base.Update();
        }

        private void DetermineState() {
            if (TotalUnits <= 0)
                resourceState = ResourceStates.Consumed;
            else
                resourceState = ResourceStates.Idle;
        }
    }
}
