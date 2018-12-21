
using System.Management;

namespace ClientScripts.Models
{
    public class BIOSInfo
    {
        public static string SerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_Bios");
            foreach(ManagementObject query in mc.GetInstances())
                if (query.Path != null)
                    return query["SerialNumber"].ToString();
            return null;
        }
    }
}