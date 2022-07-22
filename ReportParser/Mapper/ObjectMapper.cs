using CsvHelper.Configuration;
using System.Globalization;

namespace ReportParser.Mappers
{
    public class ObjectMapper<T> : ClassMap<T>
    {
        public ObjectMapper()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
