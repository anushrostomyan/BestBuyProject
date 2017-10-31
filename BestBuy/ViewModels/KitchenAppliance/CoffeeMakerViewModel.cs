using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.KitchenAppliance
{
    public class CoffeeMakerViewModel
    {
        public string CoffeeMakerModel { get; set; }
        public double? CoffeeMakerPower { get; set; }
        public CoffeeType? CoffeeMakerType { get; set; }
        public Filter? CoffeeMakeFilter { get; set; }
        public double? CoffeeMakerPrice { get; set; }
        public int? CoffeeMakerAvailability { get; set; }
        public string CoffeeMakerColor { get; set; }
        public DateTime? CoffeeMakerDate { get; set; }
        public string ImageAsBase64 { get; set; }

        public CoffeeMakerViewModel()
        {

        }


        public CoffeeMakerViewModel(string CoffeeMakerModel = null, double? CoffeeMakerPower = null, CoffeeType? CoffeeMakerType = null, Filter? CoffeeMakeFilter = null,
            double? CoffeeMakerPrice = null, int? CoffeeMakerAvailability = null, string CoffeeMakerColor = null, DateTime? CoffeeMakerDate = null, string ImageAsBase64 = null)
        {
            this.CoffeeMakerModel = CoffeeMakerModel;
            this.CoffeeMakerPower = CoffeeMakerPower;
            this.CoffeeMakerType = CoffeeMakerType;
            this.CoffeeMakeFilter = CoffeeMakeFilter;
            this.CoffeeMakerPrice = CoffeeMakerPrice;
            this.CoffeeMakerAvailability = CoffeeMakerAvailability;
            this.CoffeeMakerColor = CoffeeMakerColor;
            this.CoffeeMakerDate = CoffeeMakerDate;
            this.ImageAsBase64 = ImageAsBase64;
        }


    }
}
