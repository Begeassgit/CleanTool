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
using WpfApp1.Entity;
using WpfApp1.Function;

namespace WpfApp1
{
    /// <summary>
    /// InfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
            SysInfoFunction sysInfoFunction = new SysInfoFunction();
            SysInfo MySysInfo = sysInfoFunction.GetSysInfo();
            CPUName.Content="CPU型号："+MySysInfo.CpuName;
            CPUWidth.Content ="CPU位宽："+MySysInfo.CpuAddressWidth;
            MemoryCapacity.Content = "内存大小：" + MySysInfo.MemoryCapacity+"GB";
            MemoryManufacture.Content = "内存品牌：" + MySysInfo.MemoryManufacturer;
            MemoryName.Content = "内存类型：" + MySysInfo.MemoryName;
            GPUName.Content = "GPU型号：" + MySysInfo.GpuName;
            BoardManufacture.Content = "主板制造商：" + MySysInfo.BoardManufacturer;
            BoardName.Content = "主板类型：" + MySysInfo.BoardName;
            SysCaption.Content = "系统信息：" + MySysInfo.SysCaption;
            string tempDiskText;
            for(int i = 0; i < MySysInfo.DiskNumber; i++)
            {
                tempDiskText = "磁盘" + i + "盘符：" + MySysInfo.HardDisk["DiskName" + i]+"\n";
                DiskInfo.Text += tempDiskText;
                tempDiskText = "磁盘" + i + "容量：" + MySysInfo.HardDisk["Size" + i] + "GB\n";
                DiskInfo.Text += tempDiskText;
                tempDiskText = "磁盘" + i + "类型：" + MySysInfo.HardDisk["Type" + i] + "\n";
                DiskInfo.Text += tempDiskText;
            }
            
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
