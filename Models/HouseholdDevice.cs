namespace EnergieWebApp.Models
{
    public class HouseholdDevice
    {
        public int HouseholdId { get; set; }
        public Household Household { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
