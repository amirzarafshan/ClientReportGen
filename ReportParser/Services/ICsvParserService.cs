using ReportParser.Mappers;
using System.Collections.Generic;

namespace ReportParser.Services
{
    public interface ICsvParserService
    {
        IEnumerable<T> ReadCsvFileToMemoryInfoModel<T>(string path);
        void WriteToCsvFile<T>(string path, IEnumerable<T> models);
    } 
}