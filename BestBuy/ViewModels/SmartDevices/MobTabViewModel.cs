using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Smartphones
{
    public class MobTabViewModel
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double? Price { get; set; }
        public double? SIZE { get; set; }
        public string SIM { get; set; }
        public int? MEMORY { get; set; }
        public double? CAMERA { get; set; }
        public string CPU { get; set; }
        public int? BATTERY { get; set; }
        public MobTabEnums? MobTabType { get; set; }
        public string ImageAsBase64 { get; set; }

        public MobTabViewModel()
        {

        }

        public MobTabViewModel(int? ID = null, string name = null, string model = null, string color = null,
            double? price = null, double? size = null, string sim = null, int? memory = null,
            double? camera = null, string cpu = null, int? battery = null, MobTabEnums? mobTabType = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.Name = name;
            this.Model = model;
            this.Color = color;
            this.Price = price;
            this.SIZE = size;
            this.SIM = sim;
            this.MEMORY = memory;
            this.CAMERA = camera;
            this.CPU = cpu;
            this.BATTERY = battery;
            this.MobTabType = mobTabType;
            this.ImageAsBase64 = ImageAsBase64;
        }
    }
}
