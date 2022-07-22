
namespace ReportParser.Models
{
    public class ScreenInfoModel
    {
        public ModelBase ModelBase { get; set; }
        public string Report_Name { get; set; }
        public int? Monitors { get; set; }
        public int? Screen_Width { get; set; }
        public int? Screen_Height { get; set;}
        public bool? bLockAppWindow { get; set; }
        public int? iPosx { get; set; }
        public int? iPosY { get; set; }
        public string Screens { get; set; }
    }
}
