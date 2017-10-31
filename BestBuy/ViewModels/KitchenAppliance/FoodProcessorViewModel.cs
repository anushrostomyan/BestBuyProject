using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.KitchenAppliance
{
    public class FoodProcessorViewModel
    {
        public string FoodProcessorModel { get; set; }
        public double? FoodProcessorPower { get; set; }
        public double? FoodProcessorPrice { get; set; }
        public byte? FoodProcessorNumberOfSpeed { get; set; }
        public byte? FoodProcessorNumberOfFunction { get; set; }
        public int? FoodProcessorAvailability { get; set; }
        public string FoodProcessorColor { get; set; }
        public DateTime? FoodProcessorDate { get; set; }
        public string ImageAsBase64 { get; set; }

        public FoodProcessorViewModel()
        {

        }

        public FoodProcessorViewModel(string FoodProcessorModel = null, double? FoodProcessorPower = null,
                              double? FoodProcessorPrice = null, byte? FoodProcessorNumberOfSpeed = null, byte? FoodProcessorNumberOfFunction = null,
                              int? FoodProcessorAvailability = null, string FoodProcessorColor = null, DateTime? FoodProcessorDate = null, string ImageAsBase64 = null)
        {
            this.FoodProcessorModel = FoodProcessorModel;
            this.FoodProcessorPower = FoodProcessorPower;
            this.FoodProcessorPrice = FoodProcessorPrice;
            this.FoodProcessorNumberOfSpeed = FoodProcessorNumberOfSpeed;
            this.FoodProcessorNumberOfFunction = FoodProcessorNumberOfFunction;
            this.FoodProcessorAvailability = FoodProcessorAvailability;
            this.FoodProcessorColor = FoodProcessorColor;
            this.FoodProcessorDate = FoodProcessorDate;
            this.ImageAsBase64 = ImageAsBase64;

        }
    }
}
