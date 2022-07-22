using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace ClientScripts.Models
{
    public sealed class PCMClientInfo
    {
        private static readonly string path64 = @"C:\Program Files (x86)\PCM\V4Player\PCMClient\PCMClient.exe";
        private static readonly string path32 = @"C:\Program Files\PCM\V4Player\PCMClient\PCMClient.exe";

        private static Process process;
        public readonly string application;
        public string Version { get; set; }
        public string RamUsage { get; set; }
        public string WorkingSet { get; set; }
        public string PeakWorkingSet { get; set; }
        public string CommitSize { get; set; }
        public string PagedPool { get; set; }
        public string NonPagedPool { get; set; }
        public string Handles { get; set; }
        public string Threads { get; set; }
        public string GDIObject { get; set; }

        [DllImport("user32.dll")]
        extern public static int GetGuiResources(IntPtr hProcess, int uiFlags);

        public PCMClientInfo(string version,
                             string ramUsage, 
                             string workingSet, 
                             string peakworkingset, 
                             string commitsize, 
                             string pagedpool, 
                             string nonpagedpool, 
                             string handles,
                             string threads, 
                             string gdiobject)
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

        public static PCMClientInfo GetResouceUsage()
        {

            try
            {
                return new PCMClientInfo (GetProductVersion(),
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

        private static Process PCMClientProcess()
        {
            try { return Process.GetProcessesByName(nameof(PCMClient)).FirstOrDefault(); }
            catch { return null; }
        }

        private static string GetProductVersion()
        {
            if (Environment.Is64BitOperatingSystem)
                return FileVersionInfo.GetVersionInfo(path64).ProductVersion.Replace(',','.').ToString();
            else
                return FileVersionInfo.GetVersionInfo(path32).ProductVersion.Replace(',', '.').ToString();
        }

        private static string GetRamUsage()
        {
            try
            {
                if (Environment.OSVersion.Version.Major < 6)
                {
                    return GetWorkingSet();
                }
                else
                {
                    PerformanceCounter counter = new PerformanceCounter("Process", "Working Set - Private", nameof(PCMClient));

                    return counter.RawValue / 1024 + " K";
                }
            }
            catch { return null; }
        }

        private static string GetWorkingSet()
        {
            try
            {
                process = Process.GetProcessesByName(nameof(PCMClient)).FirstOrDefault();

                return process.WorkingSet64 / 1024 + " K";
            }
            catch { return null; }
        }

        private static string GetCommitSize()
        {
            try { return PCMClientProcess().PrivateMemorySize64 / 1024 + " K"; }
            catch { return null; }
        }

        private static string GetPeakWorkingSet()
        {
            try{return PCMClientProcess().PeakPagedMemorySize64 / 1024 + " K"; }
            catch { return null; }
        }

        private static string GetPagedPool()
        {
            try{return PCMClientProcess().PagedSystemMemorySize64 / 1024 + " K"; }
            catch { return null; }
        }

        private static string GetNonPagedPool()
        {
            try { return PCMClientProcess().NonpagedSystemMemorySize64 / 1024 + " K"; }
            catch { return null; }
        }

        private static string GetHandles()
        {
            try{return PCMClientProcess().HandleCount.ToString(); }
            catch { return null; }
        }

        private static string GetThreads()
        {
            try { return PCMClientProcess().Threads.Count.ToString(); }
            catch { return null; }
        }

        private static string GetGDIObject()
        {
            try { return GetGuiResources(PCMClientProcess().Handle, 0).ToString(); }
            catch { return null; }
        }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}

