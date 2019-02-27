using System.Collections.Generic;
using ClientScripts.Models;
using System.Management;
using System.IO;

namespace ClientScripts.Extensions
{
    public static class VideoControllerExt
    {
     
        public static VideoControllerInfo ToVideoControllerInfo(this GPUInformation gpInfo)
        {

            return new VideoControllerInfo
            {
                Description = gpInfo.Name.Trim(),
                AdapterRAM = gpInfo.AdapterRAM   
            };

        }
    }
}
