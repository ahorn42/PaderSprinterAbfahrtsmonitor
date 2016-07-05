using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaderSprinterAbfahrtsmonitor {
    class DataModelSample:DataModel {

        public DataModelSample() {
            monitorItems = new ObservableCollection<MonitorItem>();
            this.monitorItems.Add(new MonitorItem(123, "17:31", "Wewer", "4 Min", "2", "17:23"));
            this.monitorItems.Add(new MonitorItem(321, "17:42", "Kaukenberg", "2 Min", "28", "17:27"));
            this.monitorItems.Add(new MonitorItem(321, "17:42", "Kaukenberg", "2 Min", "UNI", "17:27"));
            this.stopName = "Pontanusstr";
            this.stopNameShort = "1094";
            this.timeFrame = "45";
        }

    }
}
