using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    class WifiInfo
    {
        private string ssid;
        private string bssid;
        private int rssi;
        private string password;
        private string type;

        public string SSID { get => ssid; set => ssid = value; }
        public string BSSID { get => bssid; set => bssid = value; }
        public int Rssi { get => rssi; set => rssi = value; }   
        public string Password { get => password; set => password = value; }
        public string Type { get => type; set => type = value; }
    }
}
