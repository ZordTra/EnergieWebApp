namespace EnergieWebApp.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string DeviceId { get; set; }
        public ICollection<Device>? Devices { get; set; }

        public User Account { get; set; }


    }
}
