using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace PaderSprinterAbfahrtsmonitor {
    public sealed class LiveTileMonitorTask : IBackgroundTask {

        public async void Run(IBackgroundTaskInstance taskInstance) {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            var monitor = await GetMonitorList();

            UpdateTile(monitor);

            deferral.Complete();
        }

        private static async Task<List<MonitorItem>> GetMonitorList() {
            List<MonitorItem> monitorItems = new List<MonitorItem>();
            monitorItems.Add(new MonitorItem(123, "17:31", "Wewer", "4 Min", "2", "17:23"));
            monitorItems.Add(new MonitorItem(321, "17:42", "Kaukenberg", "2 Min", "28", "17:27"));

            return monitorItems;
        }

        private static void UpdateTile(List<MonitorItem> monitorItems) {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();

            updater.EnableNotificationQueue(true);
            updater.Clear();

            int itemCount = 0;

            foreach (var mi in monitorItems) { 
                XmlDocument tileXML = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideText03);

                tileXML.GetElementsByTagName("text")[0].InnerText = mi.patternText + " " + mi.direction + " (" + mi.plannedTime + ")";

                updater.Update(new TileNotification(tileXML));

                if (itemCount++ > 5) break;
            }
        }
    }
}
