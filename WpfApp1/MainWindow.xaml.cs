
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ScanBtn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
            this.Close();
            
        }

        private void ToolBtn_Click(object sender, RoutedEventArgs e)
        {
            Tools tools = new Tools();
            tools.Show();
            this.Close();
        }
    }
}
