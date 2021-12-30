using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entity
{
    class BootInfo
    {
        private string bootItemName;
        private string bootItemUser;
        private string bootItemDetil;

        public string BootItemName { get => bootItemName; set => bootItemName = value; } 
        public string BootItemUser { get => bootItemUser; set => bootItemUser = value; }
        public string BootItemDetil { get => bootItemDetil; set => bootItemDetil = value; }
       
    }
}
