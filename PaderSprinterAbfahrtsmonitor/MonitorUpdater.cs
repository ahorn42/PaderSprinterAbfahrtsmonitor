using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.Data.Json;
using System.Diagnostics;

namespace PaderSprinterAbfahrtsmonitor {
    class MonitorUpdater {

        public async Task<List<MonitorItem>> requestData(string stopShortName, string timeFrame) {
            var now = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;

            HttpResponseMessage response; 
                var postData = new Dictionary<string, string> {
                    {"stop", stopShortName},
                    {"mode", "departure"},
                    {"startTime", now.ToString() },
                    {"timeFrame", timeFrame }
                };

                var content = new FormUrlEncodedContent(postData);

            using (var client = new HttpClient()) {
                response = await client.PostAsync("https://www.padersprinter.de/internetservice/services/passageInfo/stopPassages/stop", content);       
            }

            var responseString = await response.Content.ReadAsStringAsync();

            var json = JsonObject.Parse(responseString);

            var actualArray = json.GetObject()["actual"].GetArray();

            var mil = new List<MonitorItem>();
            
            foreach (var elem in actualArray) {
                try {
                    var actualTime = "";
                    var plannedTime = elem.GetObject()["plannedTime"].GetString();
                    var patternText = elem.GetObject()["patternText"].GetString();
                    try {
                        actualTime = elem.GetObject()["actualTime"].GetString();
                    } catch (Exception ex) {
                        Debug.WriteLine("No actualTime available for Linie " + patternText + " at planned time " + plannedTime + "!");
                    }
                    mil.Add(new MonitorItem(
                        (int)elem.GetObject()["actualRelativeTime"].GetNumber(),
                        actualTime,
                        elem.GetObject()["direction"].GetString(),
                        elem.GetObject()["mixedTime"].GetString().Replace("%UNIT_MIN%", "Min"),
                        patternText,
                        plannedTime));
                } catch (Exception ex) {
                    Debug.WriteLine("Exception: ");
                    Debug.WriteLine(ex);
                }
            }

            return mil;
        }
    }
}
