using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.KitchenAppliance
{
    public class JuicerViewModel
    {
        public string JuicerModel { get; set; }
        public double? JuicerPower { get; set; }
        public double? JuicerPrice { get; set; }
        public byte? JuicerNumberOfSpeed { get; set; }
        public double? JuicerVolme { get; set; }
        public int? JuicerAvailability { get; set; }
        public string JuicerColor { get; set; }
        public DateTime? JuicerDate { get; set; }
        public string ImageAsBase64 { get; set; }


        public JuicerViewModel()
        {

        }

        public JuicerViewModel(string JuicerModel = null, double? JuicerPower = null, double? JuicerPrice = null, byte? JuicerNumberOfSpeed = null, double? JuicerVolme = null,
          int? JuicerAvailability = null, string JuicerColor = null, DateTime? JuicerDate = null, string ImageAsBase64 = null)
        {
            this.JuicerModel = JuicerModel;
            this.JuicerPower = JuicerPower;
            this.JuicerPrice = JuicerPrice;
            this.JuicerNumberOfSpeed = JuicerNumberOfSpeed;
            this.JuicerVolme = JuicerVolme;
            this.JuicerAvailability = JuicerAvailability;
            this.JuicerColor = JuicerColor;
            this.JuicerDate = JuicerDate;
            this.ImageAsBase64 = ImageAsBase64;

        }
    }
}
