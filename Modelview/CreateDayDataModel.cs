using EnergieWebApp.Models;
using Microsoft.Identity.Client;

namespace EnergieWebApp.Modelview
{
    public class CreateDayDataModel
    {
        public DateTime Date { get; set; }
        public int accID { get; set; }
        public int Kwh {  get; set; }
    }
}
