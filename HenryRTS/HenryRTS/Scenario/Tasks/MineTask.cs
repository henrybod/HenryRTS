using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryRTS {
    public class MineTask : Task {
        public Resource Target;
        public Building DropZone;
        public int AtomicNumber;

        public MineTask(Resource target) {
            this.Target = target;
        }

    }
}
