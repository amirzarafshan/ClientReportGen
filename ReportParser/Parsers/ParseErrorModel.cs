using ClientScripts.Models;
using ClientScripts.Reports;
using ReportParser.Models;

namespace ReportParser.Parsers
{
    public class ParseErrorModel
    {
        public static ErrorModel ToErrorModel (Client client, ErrorReport errorReport)
        {
            try
            {
                return new ErrorModel
                {
                    ModelBase = ParseBaseModel.ToModelBaseInfo(client, errorReport),
                    Report_Name = nameof(ErrorReport),
                    Message = errorReport.Exception.Message,
                    StackTrace = errorReport.Exception.StackTrace
                };
            }
            catch
            {
                return new ErrorModel
                {
                    ModelBase = ParseBaseModel.ToModelBaseInfo(client, errorReport)
                };
            }
        }
    }
}
