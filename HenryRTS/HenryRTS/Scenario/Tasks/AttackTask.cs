using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryRTS {
    public class AttackTask : Task {
        public SelectableObject Target;

        public AttackTask(SelectableObject target) {
            this.Target = target;
        }

    }
}
