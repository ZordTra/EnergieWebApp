namespace EnergieWebApp.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Mode mode { get; set; }

        public TypeDevice Type {  get; set; }

        //household

    }
}
