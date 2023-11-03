namespace EnergieWebApp.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Device>? Devices { get; set; }

        public Account? Account { get; set; }
        // voor nu nullable kan verandert later
    }
}
