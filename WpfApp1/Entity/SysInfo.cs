using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    class SysInfo
    {
        private string cpuName;
        private string cpuAddressWidth;
        private string cpuStatusInfo;
        private string memoryManufacturer;
        private string memoryName;
        private string memoryCapacity;
        private string boardManufacturer;
        private string boardName;
        private Dictionary<string, string> hardDisk = new Dictionary<string, string>();
        private int diskNumber;
        private string gpuName;
        private string sysCaption;
        

        public string CpuName { get => cpuName; set => cpuName = value; }
        public string CpuAddressWidth { get => cpuAddressWidth; set => cpuAddressWidth = value; }
        public string CpuStatusInfo { get => cpuStatusInfo; set => cpuStatusInfo = value; }
        public string MemoryManufacturer { get => memoryManufacturer; set => memoryManufacturer = value; }
        public string MemoryName { get => memoryName; set => memoryName = value; }
        public string MemoryCapacity { get => memoryCapacity; set => memoryCapacity = value; }
        public string BoardManufacturer { get => boardManufacturer; set => boardManufacturer = value; }
        public string BoardName { get => boardName; set => boardName = value; }
        public string GpuName { get => gpuName; set => gpuName = value; }
        public string SysCaption { get => sysCaption; set => sysCaption = value; }
        public Dictionary<string, string> HardDisk { get => hardDisk; set => hardDisk = value; }
        public int DiskNumber { get => diskNumber; set => diskNumber = value; }
       
    }
}
