using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryRTS {
    public class FollowTask : Task {
        public readonly ControllableObject Target;

        public FollowTask(ControllableObject target) {
            this.Target = target;
        }

    }
}
