using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace ClientScripts.Models
{
    public sealed class PCMHelperInfo
    {
        private static readonly string path64 = @"C:\Program Files (x86)\PCM\V4Player\PCMHelperSvc.exe";
        private static readonly string path32 = @"C:\Program Files\PCM\V4Player\PCMHelperSvc.exe";

        private static Process process;
        public readonly string application;
        public string Version { get; set; }
        public string RamUsage { get; set; }
        public string WorkingSet { get; set; }
        public string PeakWorkingSet { get; set; }
        public string CommitSize { get; set; }
        public string PagedPool { get; set; }
        public string NonPagedPool { get; set; }
        public int? Handles { get; set; }
        public int? Threads { get; set; }
        public int? GDIObject { get; set; }
        

        [DllImport("user32.dll")]
        extern public static int GetGuiResources(IntPtr hProcess, int uiFlags);

        public PCMHelperInfo(
            string version,
            string ramUsage,
            string workingSet,
            string peakworkingset,
            string commitsize,
            string pagedpool,
            string nonpagedpool,
            int? handles,
            int? threads,
            int? gdiobject)
        {
            Version = version;
            RamUsage = ramUsage;
            WorkingSet = workingSet;
            PeakWorkingSet = peakworkingset;
            CommitSize = commitsize;
            PagedPool = pagedpool;
            NonPagedPool = nonpagedpool;
            Handles = handles;
            Threads = threads;
            GDIObject = gdiobject;
        }

        public static PCMHelperInfo GetResouceUsage()
        {
            try
            {
                return new PCMHelperInfo(GetProductVersion(),
                                         GetRamUsage(),
                                         GetWorkingSet(),
                                         GetPeakWorkingSet(),
                                         GetCommitSize(),
                                         GetPagedPool(),
                                         GetNonPagedPool(),
                                         GetHandles(),
                                         GetThreads(),
                                         GetGDIObject());
            }
            catch
            {
                return null;
            }
        }

        private static Process HelperProcess()
        {
            try { return Process.GetProcessesByName(nameof(PCMHelperSvc)).FirstOrDefault(); }
            catch { return null; }
        }

        private static string GetProductVersion()
        {
            if (Environment.Is64BitOperatingSystem)
                return FileVersionInfo.GetVersionInfo(path64).ProductVersion.ToString();
            else
                return FileVersionInfo.GetVersionInfo(path32).ProductVersion.ToString();
        }

        private static string GetRamUsage()
        {
            try
            {
                if (Environment.OSVersion.Version.Major < 6)
                {
                    return GetWorkingSet().ToString();
                }
                else
                {
                    var counter = new PerformanceCounter("Process", "Working Set - Private", nameof(PCMHelperSvc));

                    return (counter.RawValue / 1024).ToString();  
                }
            }

            catch
                { return null; }
        }

        private static string GetWorkingSet()
        {
            try
            {
                process = Process.GetProcessesByName(nameof(PCMHelperSvc)).FirstOrDefault();

                return (process.WorkingSet64 / 1024).ToString();
            }
            catch { return null; }

        }

        private static string GetCommitSize()
        {
            try { return (HelperProcess().PrivateMemorySize64 / 1024).ToString(); }
            catch { return null; }
        }

        private static string GetPeakWorkingSet()
        {
            try { return (HelperProcess().PeakPagedMemorySize64 / 1024).ToString(); }
            catch { return null; }
        }

        private static string GetPagedPool()
        {
            try { return (HelperProcess().PagedSystemMemorySize64 / 1024).ToString(); }
            catch { return null; }
        }

        private static string GetNonPagedPool()
        {
            try { return (HelperProcess().NonpagedSystemMemorySize64 / 1024).ToString(); }
            catch { return null; }
        }

        private static int? GetHandles()
        {
            try { return HelperProcess().HandleCount; }
            catch { return null; }
        }

        private static int? GetThreads()
        {
            try { return HelperProcess().Threads.Count; }
            catch { return null; }
        }

        private static int? GetGDIObject()
        {
            try { return GetGuiResources(HelperProcess().Handle, 0); }
            catch { return null; }
        }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
