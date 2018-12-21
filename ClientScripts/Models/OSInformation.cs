using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientScripts.Models
{
    public sealed class OSInformation
    {
        //OS_Info
        public string ComputerSystem { get; set; }
        public string OperatingSystem { get; set; }
        public string OperatingSystemVersion { get; set; }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
