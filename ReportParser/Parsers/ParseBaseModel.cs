using ClientScripts.Models;
using ClientScripts.Reports;
using ReportParser.Models;

namespace ReportParser.Parsers
{
    public class ParseBaseModel
    {
        public static ModelBase ToModelBaseInfo(Client client, SystemInfo sysinfo)
        {
            try
            {
                return new ModelBase
                {
                    Station_Name = client.Name,
                    Report_Version = sysinfo.Version.ToString(),                   
                    Date_Created = sysinfo.CreatedAt,
                };
            }
            catch
            {
                return new ModelBase
                {
                    Station_Name = client.Name,
                    Report_Version = "report not found."
                };
            }
         }

       public static ModelBase ToModelBaseInfo(Client client, ScreenReport sysinfo)
        {
            try
            {
                return new ModelBase
                {
                    Station_Name = client.Name,
                    Report_Version = sysinfo.Version.ToString(),
                    Date_Created = sysinfo.CreatedAt,
                };
            }
            catch
            {
                return new ModelBase
                {
                    Station_Name = client.Name,
                    Report_Version = "display information not found!",
                };
            }
        }

        public static ModelBase ToModelBaseInfo(Client client, ErrorReport errorReport)
        {
            try
            {
                return new ModelBase
                {
                    Station_Name = client.Name,
                    Report_Version = errorReport.Version.ToString(),
                    Date_Created = errorReport.CreatedAt,
                };
            }
            catch
            {
                return new ModelBase
                {
                    Station_Name = client.Name,
                    Report_Version = "Err info not found!",
                };
            }
        }
    }
}
