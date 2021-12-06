using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicReminder {
    public class ThingToRemember {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationMin { get; set; }

        public int GetDurationInSeconds() {
            return DurationMin * 60 * 1000;
        }

        public override string ToString() {
            return $"{Name};{DurationMin}";
        }
    }
}
