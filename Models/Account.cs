namespace EnergieWebApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //forgein key user
        public bool? Admin { get; set; }

        public int HouseholdId { get; set; }
        public Household? Household { get; set; }

        public DayData? Day { get; set; }

    }
}
