using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PaderSprinterAbfahrtsmonitor {

    class NameToShortNameConverter : IValueConverter {
        public static BiDictionary<string, string> translationTable = initTranslationTable();

        private static BiDictionary<string, string> initTranslationTable() {
            var ret = new BiDictionary<string, string>();

            ret.Add("Pontanusstraße", "1094");
            ret.Add("Westerntor", "1001");
            ret.Add("Hauptbahnhof", "1000");
            ret.Add("Kamp", "1008");
            ret.Add("Parkplatz", "1091");
            ret.Add("Technisches Rathaus", "1108");
            ret.Add("Uni/Südring", "1112");
            ret.Add("Uni/Schöne Aussicht", "1111");

            return ret;
        }

        public NameToShortNameConverter() {
            
        }
        
        public object Convert(object value, Type targetType, object parameter, string language) {
            return translationTable.GetBySecond((string)value)[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return translationTable.GetByFirst((string)value)[0];
        }
    }
}
