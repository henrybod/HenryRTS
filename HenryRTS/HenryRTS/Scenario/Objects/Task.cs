using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Task {
        //a controllable unit is given tasks to perform
        public enum TaskEnum {
            //here is a list of all the possible actions a ControllableObject may perform
            Move,
            Follow,
            Attack,
            Repair,
            Mine,
            HoldPosition,
            Idle
        }
        private TaskEnum type;
        private Point destination;
        private SelectableObject target;


        public Task() {
            SetIdle();
        }

        public TaskEnum GetType() {
            return type;
        }
        public void SetIdle() {
            //make this task an idle one
            type = TaskEnum.Idle;
        }
        public void SetMove(Point p) {
            //make this task an idle one
            type = TaskEnum.Move;
        }
        public void SetFollow(SelectableObject so) {
            //make this task an idle one
            type = TaskEnum.Follow;
            target = so;
        }
        public void SetAttack(SelectableObject so) {
            //make this task an idle one
            type = TaskEnum.Attack;
            target = so;
        }
        public void SetRepair(SelectableObject so) {
            //make this task an idle one
            type = TaskEnum.Repair;
            target = so;
        }
        public void SetMine(SelectableObject so) {
            //make this task an idle one
            type = TaskEnum.Mine;
            target = so;
        }
        public void SetHold() {
            //make this task an idle one
            type = TaskEnum.HoldPosition;
        }
    }
}
