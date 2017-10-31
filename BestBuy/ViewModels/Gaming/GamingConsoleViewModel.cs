using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Gaming
{
    public class GamingConsoleViewModel
    {
        public string   Name { get;  set; }
        public string   Developer { get;  set; }
        public string   Manufacturer { get;  set; }
        public string   ProductFamily { get;  set; }
        public string   Generation { get;  set; }
        public bool?    RetailAvailability { get;  set; }
        public decimal? Price { get;  set; }
        public string   Graphics { get;  set; }
        public string   Display { get; set; }
        public string   BestSellingGame { get;  set; }
        public string   ImageAsBase64 { get; set; }

        public GamingConsoleViewModel()
        {
        }

        public GamingConsoleViewModel(string name, string developer, string manufacturer, string productFamily, string generation,
            bool? retailAvailability, decimal? price, string graphics, string display, string bestSellingGame, string imageAsBase64)
        {
            Name = name;
            Developer = developer;
            Manufacturer = manufacturer;
            ProductFamily = productFamily;
            Generation = generation;
            RetailAvailability = retailAvailability;
            Price = price;
            Graphics = graphics;
            Display = display;
            BestSellingGame = bestSellingGame;
            ImageAsBase64 = imageAsBase64;
        }
    }
}
