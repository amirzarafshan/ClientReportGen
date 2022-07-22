using ClientScripts.Models;
using ClientScripts.Reports;
using Newtonsoft.Json;
using ReportParser.Models;
using System;
using System.Linq;

namespace ReportParser.Parsers
{
    public class ParseScreenInfoModel
    {
        public static ScreenInfoModel ToScreenInfoModel (Client client, ScreenReport info)
        {
            try
            {
                return new ScreenInfoModel
                {
                    ModelBase = ParseBaseModel.ToModelBaseInfo(client, info),
                    Report_Name = nameof(ScreenReport),
                    //Monitors = info.Displays.Length,
                    //Screen_Width = info.Displays.Where(x => x.Primary).FirstOrDefault().WorkingArea.Width,
                   // Screen_Height = info.Displays.Where(x => x.Primary).FirstOrDefault().WorkingArea.Height,
                   // bLockAppWindow = info.ClientParams.bLockAppWindow,
                   // iPosx = info.ClientParams.iPosX,
                   // iPosY = info.ClientParams.iPosY,
                   // Screens = String.Join("\" ", JsonConvert.SerializeObject(info.Displays, Formatting.None).ToLowerInvariant().Split(',')),
                };
            }
            catch
            {
                return new ScreenInfoModel
                {                  
                    ModelBase = ParseBaseModel.ToModelBaseInfo(client, info)
                };
            }
        }
    }
}
