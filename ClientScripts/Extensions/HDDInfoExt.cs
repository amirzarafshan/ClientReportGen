using System;
using System.IO;
using ClientScripts.Models;
using System.Management;

namespace ClientScripts.Extensions
{
    public static class HDDInfoExt
    {
        private const int MegaByte = 1048576;

        public static LogicalDriveInfo ToHDDInfo (this DriveInfo driveInfo)
        {
            if (driveInfo == null)
                throw new ArgumentException(nameof(driveInfo));

            if (driveInfo.IsReady)
                return new LogicalDriveInfo
                {
                    DriveName = driveInfo.Name.Trim(),
                    SerialNumber = VolumeSerialNumber(driveInfo.Name).Trim(),
                    FileSystem = driveInfo.DriveFormat.Trim(),
                    Size = driveInfo.TotalSize/ MegaByte,
                    FreeSpace = driveInfo.AvailableFreeSpace/MegaByte
                };
            else
            {
                return new LogicalDriveInfo
                {
                    DriveName = driveInfo.Name.Trim(),
                    SerialNumber = VolumeSerialNumber(driveInfo.Name).Trim()
                };
            }
        }
        
        private static string VolumeSerialNumber(string driveLetter)
        {
            try
            {
                ManagementObject mObject = new ManagementObject("Win32_LogicalDisk.DeviceID='" + driveLetter.TrimEnd('\\') + "'");
                if (mObject == null)
                    throw new ManagementException();

                return mObject["VolumeSerialNumber"]?.ToString() ?? "no serial number found";
            }
            catch
            {
                return string.Empty;
            }
       }

    }
}
