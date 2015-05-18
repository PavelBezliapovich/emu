using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emu
{
    class EmuMicroprocessorState
    {
        public string EIP { get; set; }
        public string EAXPP { get; set; }
        public string BR1 { get; set; }
        public string BR2 { get; set; }
        public string PK { get; set; }
        public bool Flag { get; set; }
    }
}
