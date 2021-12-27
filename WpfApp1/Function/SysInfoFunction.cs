using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entity;
using System.Management;
using System.IO;

namespace WpfApp1.Function
{
    class SysInfoFunction
    {
        public SysInfo GetSysInfo()
        {
            SysInfo sysInfo = new SysInfo();
            int countMemory = 0;
            int countDisk = 0;
            double temp;
            try
            {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * FROM Win32_Processor");
                foreach(ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    sysInfo.CpuName = managementObject["Name"].ToString().Trim();
                    sysInfo.CpuAddressWidth = managementObject["AddressWidth"].ToString().Trim();
                    sysInfo.CpuStatusInfo = managementObject["StatusInfo"].ToString().Trim();
                }

                managementObjectSearcher = new ManagementObjectSearcher("Select * FROM Win32_PhysicalMemory");
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    countMemory++;
                    temp = double.Parse(managementObject["Capacity"].ToString().Trim()) / 1024 / 1024 / 1024 * countMemory;
                    sysInfo.MemoryCapacity = temp.ToString().Trim();
                    sysInfo.MemoryManufacturer = managementObject["Manufacturer"].ToString().Trim();
                    sysInfo.MemoryName = managementObject["Name"].ToString().Trim();
                    
                }

                DriveInfo[] driveInfos = DriveInfo.GetDrives();
                foreach (DriveInfo driveInfo in driveInfos)
                {
                    if (driveInfo.IsReady)
                    {
                        var tempSize = driveInfo.TotalSize / 1024.0 / 1024.0 / 1024.0;
                        sysInfo.HardDisk.Add("DiskName"+countDisk, driveInfo.Name);
                        sysInfo.HardDisk.Add("Size" + countDisk, tempSize.ToString("f2"));
                        sysInfo.HardDisk.Add("Type" + countDisk, driveInfo.DriveType.ToString());
                        countDisk++;
                    }
                }
                sysInfo.DiskNumber = countDisk;

                managementObjectSearcher = new ManagementObjectSearcher("Select * FROM Win32_DisplayConfiguration");
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    sysInfo.GpuName = managementObject["DeviceName"].ToString().Trim();
                }
                managementObjectSearcher = new ManagementObjectSearcher("Select * FROM Win32_BaseBoard");
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    sysInfo.BoardManufacturer = managementObject["Manufacturer"].ToString().Trim();
                    sysInfo.BoardName = managementObject["Name"].ToString().Trim();
                }
                managementObjectSearcher = new ManagementObjectSearcher("Select * FROM Win32_OperatingSystem");
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    sysInfo.SysCaption = managementObject["Caption"].ToString().Trim();
                }
             
            }
            catch
            {
                sysInfo.CpuName = null;
            }
            return sysInfo;
        }
       

    }
}
