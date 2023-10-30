namespace EnergieWebApp.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ModeId { get; set; }

        public Mode Modes { get; set; }
        public int? TypeDeviceId { get; set; }

        public TypeDevice Type {  get; set; }


    }
}
