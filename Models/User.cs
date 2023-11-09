namespace EnergieWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public Household? Household { get; set; }
        public int? HouseholdId { get; set; }
        public string Name { get; set; }
        public ICollection<DayData>? DayDatas { get; set; }
        Account Account { get; set; }
        public int AccountId { get; set; }
        public int? Score { get; set; }

    }
}