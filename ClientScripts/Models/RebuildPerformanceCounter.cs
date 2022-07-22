using System;
using System.Diagnostics;
using System.Threading;

namespace ClientScripts.Models
{
    // On some units method GetRamUsage() returns null due to non-existance of category name 'process'. In this scenario performance counter library values need to be manually rebuilt, this 
    // can be accomplished using lodctr.exe /r located in windows\system32. [https://docs.microsoft.com/en-us/troubleshoot/windows-server/performance/rebuild-performance-counter-library-values].

    public class RebuildPerformanceCounter
    {       
        private static readonly string path = @"C:\Windows\System32";

        public static void Start()
        {
            if (!CategoryExist(nameof(Process)))
            {
                Process p = new Process
                {
                    StartInfo = new ProcessStartInfo("lodctr.exe")
                };
                p.StartInfo.Arguments = "/r";
                p.StartInfo.WorkingDirectory = path;
                p.StartInfo.ErrorDialog = false;
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.Verb = "runas";

                try
                {
                    for (int i = 0; i < 2; i++)
                    {
                        p.Start();
                        while (!p.HasExited)
                        {
                            p.Refresh();
                            Thread.Sleep(1500);
                        }
                        p.WaitForExit();
                    };
                    p.Close();
                }
                catch { }
            }
        }

        private static bool CategoryExist(string name)
        {
            try
            {
                return PerformanceCounterCategory.Exists(nameof(name));
            }
            catch
            {
                return false;
            }
        }
    }
}
