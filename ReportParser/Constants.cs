
namespace ReportParser
{
    public static class Constants
    {

        public class CsvBaseInfoHeaders
        {
            public const string Client = "Station_Name";            
            public const string Version = "Report_Version";
            public const string Date_Created = "Date_Created";
            public const string Report_Name = "Report_Name";
        }
        public class CsvMemInfoHeaders
        {            
            public const string OS = "Operating_System";
            public const string Application = "Application_Name";
            public const string Build = "Build";
            public const string PagingFile = "Paging_File(size_MB)";
            public const string RamUsage = "Ram_Usage";
            public const string WorkingSet = "Working_Set (K)";
            public const string PeakWorkingSet = "Peak_Working_Set (K)";
            public const string CommitSize = "CommitSize (K)";
            public const string PagedPool = "Paged_Pool (K)";
            public const string NonPagedPool = "Non_Paged_Pool (K)";
            public const string Handles = "Handles";
            public const string Threads = "Threads";
            public const string GDIObject = "GDI_Object";
        }

        public class CsvScreenInfoHeaders
        {
            public const string Monitors = "Monitors_change";
            public const string Screen_Width = "Screen_Width";
            public const string Screen_Height = "Screen_Height";
            public const string bLockAppWindow = "bLockAppWindow";
            public const string iPosX = "iPosX";
            public const string iPosY = "iPosY";
            public const string Screens = "Screens";
        }

        public class CsvSystemInfoHeaders
        {
            public const string Computer_System = "Computer_System";
            public const string Screen_Width = "Screen_Width";
            public const string Screen_Height = "Screen_Height";
            public const string bLockAppWindow = "bLockAppWindow";
            public const string iPosX = "iPosX";
            public const string iPosY = "iPosY";
            public const string Screens = "Screens";
        }
    }
}
