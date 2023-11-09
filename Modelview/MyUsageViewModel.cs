using EnergieWebApp.Models;

namespace EnergieWebApp.Modelview
{
    public class MyUsageViewModel
    {
        public int accID {  get; set; } 
        public List<DayData> DayDatas { get; set; }
        public int? AverageKwh {  get; set; }
    }
}
