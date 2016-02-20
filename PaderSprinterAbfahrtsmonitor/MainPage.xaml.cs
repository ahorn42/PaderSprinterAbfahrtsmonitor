using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PaderSprinterAbfahrtsmonitor {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        DataModel dm;

        public MainPage() {
            this.InitializeComponent();
            dm = new DataModel() { stopName = "platzhalter" };
            dm.monitorItems.Add(new MonitorItem(123, "17:31", "Wewer", "4 Min", "2", "17:23"));
            this.DataContext = dm;
        }

        public string stop;
    }
}
