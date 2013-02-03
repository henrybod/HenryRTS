using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryRTS {
    public class IdleTask : Task {
        public IdleTask() {
            Finished = true;
        }
    }
}
