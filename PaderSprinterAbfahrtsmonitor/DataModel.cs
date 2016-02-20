using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaderSprinterAbfahrtsmonitor
{
    class DataModel
    {
        public string stopName { get; set; }
        public ObservableCollection<MonitorItem> monitorItems {
            get; set;
        }

        public DataModel () {
            monitorItems = new ObservableCollection<MonitorItem>();
        }
    }
}
 