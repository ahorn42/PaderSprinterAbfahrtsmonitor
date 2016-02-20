using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaderSprinterAbfahrtsmonitor {
    class MonitorItem {
        public int actualRelativeTime { get; }
        public string actualTime { get; }
        public string direction { get; }
        public string mixedTime { get; }
        public string patternText { get; }
        public string plannedTime { get; }

        public MonitorItem (int actualRelativeTime, string actualTime, string direction, string mixedTime, string patternText, string plannedTime) {
            this.actualRelativeTime = actualRelativeTime;
            this.actualTime = actualTime;
            this.direction = direction;
            this.mixedTime = mixedTime;
            this.patternText = patternText;
            this.plannedTime = plannedTime;
        }
    }
}
