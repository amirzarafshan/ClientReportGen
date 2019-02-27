using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientScripts.Models
{
    public sealed class TVInfo
    {
        public string TV_version { get; set; }
        public long TV_clientID { get; set; }

        public TVInfo(string version, long clientID)
        {
            TV_version = version;
            TV_clientID = clientID;
        }

        public static List<TVInfo> AllTeamViewerInfo()
        {
            List<TVInfo> tvInfos = new List<TVInfo>();
            foreach (RegistryKey key in GetTeamViewerRegistryKeys())
                tvInfos.Add(new TVInfo(key.GetValue("Version").ToString().Trim(), Convert.ToUInt32(key.GetValue("ClientID"))));

            return tvInfos;
        }

        public static List<RegistryKey> GetTeamViewerRegistryKeys()
        {

            List<RegistryKey> keys = new List<RegistryKey>();

            if (Environment.Is64BitOperatingSystem)
            {
                var oldVerKeys64 = Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath64Bit).GetSubKeyNames().Where(x => x.ToLowerInvariant().Contains("version"));
                if (Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath64Bit).ValueCount > 0)
                    keys.Add(Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath64Bit));

                foreach (string oldKey64 in oldVerKeys64)
                    keys.Add(Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath64Bit + oldKey64));
            }

            else
            {
                var oldVerKeys32 = Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath32Bit).GetSubKeyNames().Where(x => x.ToLowerInvariant().Contains("version"));
                if (Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath32Bit).ValueCount > 0)
                    keys.Add(Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath32Bit));

                foreach (string oldKey32 in oldVerKeys32)
                    keys.Add(Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath32Bit + oldKey32));
            }
            return keys;
        }

        public override string ToString()
        {
            return Serializer.ToString(this);
            
        }
    }
}
