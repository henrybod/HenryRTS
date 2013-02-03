using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryRTS {
    public class PatrolTask : Task {
        public readonly Point Destination;

        public PatrolTask(Point destination) {
            this.Destination = destination;
        }

    }
}
