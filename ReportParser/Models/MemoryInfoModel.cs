using CsvHelper.Configuration.Attributes;

namespace ReportParser.Models
{
    public class MemoryInfoModel //: ModelBase
    {    
        public ModelBase ModelBase { get; set; }
        public string Report_Name { get; set; }
        public string Operating_System { get; set; }
        public string Application_Name { get; set; }
        public string Build { get; set; }

        [Name("Paging_File (MB)")]
        public string Paging_File { get; set; }

        public string Ram_Usage { get; set; }

        [Name("Working_Set (K)")]
        public string Working_Set { get; set; }

        [Name("Peak_WorkingSet (K)")]
        public string Peak_WorkingSet { get; set; }

        [Name("CommitSize (K)")]
        public string CommitSize { get; set; }

        [Name("Paged_Pool (K)")]
        public string Paged_Pool { get; set; }

        [Name("Non_Paged_Pool (K)")]
        public string Non_Paged_Pool { get; set; }

        public int? Handles { get; set; }
        public int? Threads { get; set; }
        public int? GDI_Object { get; set; }
    }
}
