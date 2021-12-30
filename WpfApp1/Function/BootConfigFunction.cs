using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entity;
using Microsoft.Win32;

namespace WpfApp1.Function
{
    class BootConfigFunction
    {
        public List<BootInfo> GetBootInfos()
        {
            List<BootInfo> bootInfos = new List<BootInfo>();
           
            RegistryKey registryKeyLocal 
                = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            RegistryKey registryKeyUser 
                = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            foreach (string name in registryKeyLocal.GetValueNames())
            {
                if (name.Equals(""))
                {
                    continue;
                }
                BootInfo myBootInfo = new BootInfo
                {
                    BootItemName = name
                };
                bootInfos.Add(myBootInfo);
            }
            foreach (string name in registryKeyUser.GetValueNames())
            {
                if (name.Equals(""))
                {
                    continue;
                }
                BootInfo myBootInfo = new BootInfo
                {
                    BootItemName = name
                };
                bootInfos.Add(myBootInfo);
            }

            return bootInfos;

        }
    }
}
