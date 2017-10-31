using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.KitchenAppliance
{
    public class MicrowavesViewModel
    {
        public string MicrowaveModel { get; set; }
        public double? MicrowavePower { get; set; }
        public double? MicrowaveVolme { get; set; }
        public double? MicrowavePrice { get; set; }
        public int? MicrowaveAvailability { get; set; }
        public string MicrowaveColor { get; set; }
        public DateTime? MicrowaveDate { get; set; }
        public string ImageAsBase64 { get; set; }

        public MicrowavesViewModel()
        {

        }

        public MicrowavesViewModel(string MicrowaveModel = null, double? MicrowavePower = null, double? MicrowaveVolme = null, double? MicrowavePrice = null,
            int? MicrowaveAvailability = null, string MicrowaveColor = null, DateTime? MicrowaveDate = null, string ImageAsBase64 = null)
        {
            this.MicrowaveModel = MicrowaveModel;
            this.MicrowavePower = MicrowavePower;
            this.MicrowaveVolme = MicrowaveVolme;
            this.MicrowavePrice = MicrowavePrice;
            this.MicrowaveAvailability = MicrowaveAvailability;
            this.MicrowaveColor = MicrowaveColor;
            this.MicrowaveDate = MicrowaveDate;
            this.ImageAsBase64 = ImageAsBase64;

        }


    }
}
