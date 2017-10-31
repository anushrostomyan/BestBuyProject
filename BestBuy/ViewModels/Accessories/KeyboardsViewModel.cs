using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Accessories
{
    public class KeyboardsViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int? NumberOfKeys { get; set; }
        public string OS { get; set; }
        public double? Price { get; set; }
        public string ConnectionTechnology { get; set; }
        public int? Availability { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string ImageAsbase64 { get; set; }


        public KeyboardsViewModel()
        {
                
        }


        public KeyboardsViewModel(string Name, string Brand, string Color, int? NumberOfKeys, string OS,
                                  double? Price, string ConnectionTechnology, int? Availability, 
                                  DateTime? ProductionDate, string ImageAsbase64)
        {
            this.Name = Name;
            this.Brand = Brand;
            this.Color = Color;
            this.NumberOfKeys = NumberOfKeys;
            this.OS = OS;
            this.Price = Price;
            this.ConnectionTechnology = ConnectionTechnology;
            this.Availability = Availability;
            this.ProductionDate = ProductionDate;
            this.ImageAsbase64 = ImageAsbase64;
        }
    }
}
