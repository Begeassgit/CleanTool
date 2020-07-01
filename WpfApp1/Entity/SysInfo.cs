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
        private string cpuArchitecture;
        private string cpuStatusInfo;
        private string memoryManufacturer;
        private string memoryName;
        private string memoryCapacity;
        private string boardManufacturer;
        private string boardName;
        private string[] hardDiskName= new string[10];
        private string hardDiskSize;
        private string gpuName;
        private string sysCaption;
        

        public string CpuName { get => cpuName; set => cpuName = value; }
        public string CpuAddressWidth { get => cpuAddressWidth; set => cpuAddressWidth = value; }
        public string CpuArchitecture { get => cpuArchitecture; set => cpuArchitecture = value; }
        public string CpuStatusInfo { get => cpuStatusInfo; set => cpuStatusInfo = value; }
        public string MemoryManufacturer { get => memoryManufacturer; set => memoryManufacturer = value; }
        public string MemoryName { get => memoryName; set => memoryName = value; }
        public string MemoryCapacity { get => memoryCapacity; set => memoryCapacity = value; }
        public string BoardManufacturer { get => boardManufacturer; set => boardManufacturer = value; }
        public string BoardName { get => boardName; set => boardName = value; }
        public string HardDiskSize { get => hardDiskSize; set => hardDiskSize = value; }
        public string GpuName { get => gpuName; set => gpuName = value; }
        public string SysCaption { get => sysCaption; set => sysCaption = value; }
        public string[] HardDiskName { get => hardDiskName; set => hardDiskName = value; }
       
    }
}
