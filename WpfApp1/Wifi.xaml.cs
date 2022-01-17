using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Function;
using WpfApp1.Entity;


namespace WpfApp1
{
    /// <summary>
    /// Wifi.xaml 的交互逻辑
    /// </summary>
    public partial class Wifi : Window
    {
        public Wifi()
        {
            InitializeComponent();
            WifiPasswordFunction wifiPasswordFunction = new WifiPasswordFunction();
            wifiPasswordFunction.GetSSID();
            wifiPasswordFunction.GetWifiType();
            password.Text = "密码："+wifiPasswordFunction.SetPassword().Password;
            QRCode.Source = wifiPasswordFunction.BitmapToImage(wifiPasswordFunction.MyQRCode());
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            Tools tools = new Tools();
            tools.Show();
            this.Close();
        }

    }
}
