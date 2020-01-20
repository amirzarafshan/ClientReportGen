using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientScripts.Models
{
    public sealed class TVInfo
    {
        public string Version { get; set; }
        public long ClientId { get; set; }

        public TVInfo(string version, long clientId)
        {
            Version = version;
            ClientId = clientId;
        }

        public static List<TVInfo> GetTVInfo()
        {
           
                var tvInfos = new List<TVInfo>();
                foreach (RegistryKey key in GetTeamViewerRegistryKeys())
                    tvInfos.Add(new TVInfo(key.GetValue("Version").ToString().Trim(), Convert.ToUInt32(key.GetValue("ClientID"))));

                return tvInfos;
        }

        public static List<RegistryKey> GetTeamViewerRegistryKeys()
        {

            var keys = new List<RegistryKey>();

            if (Environment.Is64BitOperatingSystem)
            {
                var oldVerKeys64 = Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath64Bit).GetSubKeyNames().Where(x => x.ToLowerInvariant().Contains("version"));
                if (Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath64Bit).ValueCount > 0)
                {
                    keys.Add(Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath64Bit));
                }

                if (oldVerKeys64 != null)
                {
                    keys.AddRange(oldVerKeys64.Select(oldKey64 => Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath64Bit + oldKey64)));
                }

            }

            else
            {
                var oldVerKeys32 = Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath32Bit)?.GetSubKeyNames().Where(x => x.ToLowerInvariant().Contains("version"));
                if (Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath32Bit)?.ValueCount > 0)
                    keys.Add(Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath32Bit));

                if (oldVerKeys32 != null)
                {
                    keys.AddRange(oldVerKeys32.Select(oldKey32 => Registry.LocalMachine.OpenSubKey(RegistryKeysInfo.TeamViewerPath32Bit + oldKey32)));
                }
            }
            return keys;
        }

        public override string ToString()
        {
            return Serializer.ToString(this);
            
        }
    }
}
