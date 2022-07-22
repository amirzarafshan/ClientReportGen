using ReportParser.Mappers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvHelper;
using System.Linq;
using System;

namespace ReportParser.Services
{
    public class CsvParserService : ICsvParserService
    { 
        //reader not used for now
        public IEnumerable<T> ReadCsvFileToMemoryInfoModel<T>(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path, Encoding.Default))
                using (CsvReader csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.Configuration.RegisterClassMap(new ObjectMapper<T>());
                    var records = csv.GetRecords<T>().ToList();
                    return records;
                }
            }

            catch (UnauthorizedAccessException e){throw new Exception(e.Message);}
            catch (FieldValidationException e) { throw new Exception(e.Message); }
            catch (CsvHelperException e) { throw new Exception(e.Message); }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void WriteToCsvFile<T>(string path, IEnumerable<T> models)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, System.Globalization.CultureInfo.CurrentCulture))
            {
                cw.WriteHeader<T>();
                cw.NextRecord();
                cw.WriteRecords("");
                cw.NextRecord();

                //use this to write all @ once//
                cw.WriteRecords(models.Select(memInfo => memInfo));

                //--Use this foreach to write--//
                /*foreach (MemoryInfoModel memInfo in memoryInfoModels)
                {
                  cw.WriteRecord(memInfo);
                  cw.NextRecord();
                } */
            }
        }
    }
}
