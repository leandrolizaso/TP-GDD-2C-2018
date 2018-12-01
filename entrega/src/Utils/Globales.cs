using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace PalcoNet.Utils {
    public static class Globales {
        private static Dictionary<string, string> data;

        public static string getUrlDB() {
            string server = getProperty("Data Source");
            string catalog = getProperty("Initial Catalog");
            string user = getProperty("User ID");
            string pass = getProperty("Password");
            return "Data Source="+server+";Initial Catalog="+catalog+";User ID="+user+";Password="+pass;
        }

        public static DateTime getFechaHoy() {
            return DateTime.Parse(getProperty("Fecha"));
        }

        public static string getProperty(string prop) {
            loadProps();
            return data[prop];
        }

        private static void loadProps() {
            if (data == null) {
                data = new Dictionary<string, string>();
                string path = Path.Combine(Application.StartupPath, "application.properties");
                foreach (var linea in File.ReadAllLines(path)) {
                    int pos = linea.IndexOf("=");
                    string prop = linea.Substring(0, pos);
                    string val = linea.Substring(pos + 1);
                    data.Add(prop, val);
                }
            }
        }

    }
}