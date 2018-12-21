using System;
using System.IO;
using ClientScripts.Models;
using System.Management;

namespace ClientScripts.Extensions
{
    public static class HDDInfoExt
    {

        public static LogicalDriveInfo ToHDDInfo (this DriveInfo driveInfo)
        {
            const int ToMB = 1048576;

            if (driveInfo == null)
                throw new ArgumentException(nameof(driveInfo));

            return new LogicalDriveInfo
            {
                DriveName = driveInfo.Name,
                SerialNumber = VolumeSerialNumber(driveInfo.Name),
                FileSystem = driveInfo.DriveFormat,
                Size = driveInfo.TotalSize/ToMB,
                FreeSpace = driveInfo.AvailableFreeSpace/ToMB
            };
        }
        
        private static string VolumeSerialNumber(string driveLetter)
        {
            ManagementObject mObject = new ManagementObject("Win32_LogicalDisk.DeviceID='" + driveLetter.TrimEnd('\\') + "'");
            if (mObject == null)
                throw new ManagementException();

            return mObject["VolumeSerialNumber"].ToString();    
       }
    }
}
