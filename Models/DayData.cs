namespace EnergieWebApp.Models
{
    public class DayData
    {
        //user
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int Kwh {  get; set; }
    }
}
