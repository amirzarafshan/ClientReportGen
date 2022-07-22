using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportParser.Models
{
    public class ErrorModel
    {
        public ModelBase ModelBase { get; set; }
        public string Report_Name { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
