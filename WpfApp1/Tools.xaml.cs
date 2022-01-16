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

namespace WpfApp1
{
    /// <summary>
    /// Tools.xaml 的交互逻辑
    /// </summary>
    public partial class Tools : Window
    {
        public Tools()
        {
            InitializeComponent();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SpeedTestBtn_Click(object sender, RoutedEventArgs e)
        {
            Speed speed = new Speed();
            speed.Show();
            this.Close();
        }

        private void BootBtn_Click(object sender,RoutedEventArgs e)
        {
            BootConfig bootConfig = new BootConfig();
            bootConfig.Show();
            this.Close();
        }

        private void WifiBtn_Click(object sender,RoutedEventArgs e)
        {
            Wifi wifi = new Wifi();
            wifi.Show();
            this.Close();
        }
    }
}
