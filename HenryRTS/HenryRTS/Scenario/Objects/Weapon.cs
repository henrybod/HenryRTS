using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Weapon {
        //weapons have a range
        private float range = 0.0f; //melee range default
        public float Range {
            get { return range; }
        }

        //weapons have a fire rate
        private float fireRate = 1.0f; //1 shot per second default
        public float FireRate {
            get { return fireRate; }
        }
        public float CoolDown {
            get { return 1.0f / fireRate; }
        }
        private float timeElapsed = 0.0f;

        //weapons spawn bullets
        //private List<Bullet> myBullets = new List<Bullet>();


        public void FireAt(Point p) {
            if (timeElapsed >= CoolDown) {

            }
        }

        public void Update() {
            timeElapsed += Global.t;
     //       foreach (Bullet b in myBullets) {
                //update each bullet
      //      }
        }
    }
}
