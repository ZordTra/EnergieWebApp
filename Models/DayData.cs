namespace EnergieWebApp.Models
{
    public class DayData
    {
        public User Account { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Kwh {  get; set; }
        public ICollection<Device>? Devices { get; set; }


    }
}
