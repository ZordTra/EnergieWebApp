using Microsoft.Identity.Client;

namespace EnergieWebApp.Models
{
    public class CreateDayDataModel
    {
        public DateTime Date { get; set; }
        public int accID { get; set; }
        public int Kwh { get; set; }
    }
}
