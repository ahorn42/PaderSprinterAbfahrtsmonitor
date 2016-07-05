using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PaderSprinterAbfahrtsmonitor {
    class Stop {
        public string name { get; set; }
        public string shortName { get; set; }

        public Stop(string name, string shortName) {
            this.name = name;
            this.shortName = shortName;
        }
    }

    class DataModel : INotifyPropertyChanged {
        private string _stopName;
        public string stopName {
            get {
                return _stopName;
            }
            set {
                if (_stopName != value) {
                    _stopName = value;
                    this.updateDm();
                    OnPropertyChanged();
                }
            }
        }

        private string _stopNameShort;
        public string stopNameShort {
            get {
                return _stopNameShort;
            }
            set {
                if (_stopNameShort != value) {
                    _stopNameShort = value;
                    this.updateDm();
                    OnPropertyChanged();
                }
            }
        }

        private string _timeFrame;
        public string timeFrame {
            get {
                return _timeFrame;
            }
            set {
                if (_timeFrame != value) {
                    _timeFrame = value;
                    this.updateDm();
                    OnPropertyChanged();
                }
            }
        }

        public int timeFrameInt {
            get {
                int ret = 60;
                try {
                    ret = int.Parse(timeFrame);
                } catch (Exception e) {
                    Debug.WriteLine(e.Message);
                }
                return ret;
            }
            set {
                timeFrame = value.ToString();
            }
        }

        public ObservableCollection<MonitorItem> monitorItems {
            get; set;
        }

        public ObservableCollection<Stop> stops {
            get; set;
        }

        public DataModel() {
            monitorItems = new ObservableCollection<MonitorItem>();
            stops = new ObservableCollection<Stop>();

            this.initStops();
        }

        public void updateDm() {
            updateDm(null, null);
        }

        public async void updateDm(object sender, object e) {
            this.monitorItems.Clear();
            List<MonitorItem> reqItems = new List<MonitorItem>();

            try {
                reqItems = await (new MonitorUpdater()).requestData(this.stopNameShort, this.timeFrame);
            } catch (Exception ex) {
                Debug.WriteLine("Exception:");
                Debug.WriteLine(ex);
            }

            foreach (var ri in reqItems) {
                this.monitorItems.Add(ri);
            }
        }

        private void initStops() {
            foreach (var stop in NameToShortNameConverter.translationTable.secondToFirst) {
                this.stops.Add(new Stop(stop.Value.First(), stop.Key));
            }
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] String caller = null) {
            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
