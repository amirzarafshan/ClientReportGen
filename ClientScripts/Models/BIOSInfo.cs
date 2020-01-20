
using System.Management;

namespace ClientScripts.Models
{
    public class BIOSInfo
    {
        public static string GetSerialNumber()
        {
            try
            {
                using (var mc = new ManagementClass("Win32_Bios"))
                {
                    lock (mc.GetInstances().SyncRoot)
                        foreach (var o in mc.GetInstances())
                        {
                            var query = (ManagementObject)o;
                            if (query?.Path != null)
                                return query["SerialNumber"].ToString();
                        }

                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
  
            }
        }
    }
}