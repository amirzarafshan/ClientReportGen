using System;
using System.IO;
using ClientScripts;
using ClientScripts.Reports;
using Newtonsoft.Json.Linq;
using RXMusic.Common.Logging;

namespace ReportParser
{
    public class ReportReader
    {

        public static bool IsValidType<T>(string file)
        {
            try
            {
                var report = Serializer.ToObject<JObject>(File.ReadAllText(file));
                return report[nameof(ReportBase.ReportName).ToLowerInvariant()].ToString()
                    .Equals(typeof(T).Name, StringComparison.OrdinalIgnoreCase);
   
            }
            catch (Exception e)
            {
                Log.Error(file, e);
                return false;
            }
        }

        public static ErrorReport ReadErrorReportFromFile(string file)
        {
            return Serializer.ToObject<ErrorReport>(File.ReadAllText(file));;
        }

        public static ScreenReport ReadScreenReportFromFile(string file)
        {
            return Serializer.ToObject<ScreenReport>(File.ReadAllText(file));;
        }

    }
}
