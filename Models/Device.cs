﻿namespace EnergieWebApp.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Mode { get; set; }
        public int? TypeDeviceId { get; set; }

        public TypeDevice Type {  get; set; }


    }
}
