using CsvHelper.Configuration.Attributes;
using System;

namespace ReportParser.Models
{
    public class ModelBase
    {
        public string Station_Name { get; set; }
        public string Report_Version { get; set; }
        public DateTime? Date_Created { get; set; }     
    }
}
