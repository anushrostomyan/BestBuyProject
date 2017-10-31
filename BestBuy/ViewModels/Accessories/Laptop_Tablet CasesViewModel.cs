using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Accessories
{
    public class LaptopTabletCasesViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public double? Price { get; set; }
        public double? Size { get; set; }
        public double? Weight { get; set; }
        public string Material { get; set; }
        public int? Availability { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string ImageAsBase64 { get; set; }




        public LaptopTabletCasesViewModel()
        {

        }

        public LaptopTabletCasesViewModel(string Name, string Brand, string Color, double? Price, double? Size, double? Weight, string Material,
                                            int? Availability, DateTime? ProductionDate, string ImageAsBase64)
        {
            this.Name = Name;
            this.Brand = Brand;
            this.Color = Color;
            this.Price = Price;
            this.Size = Size;
            this.Weight = Weight;
            this.Material = Material;
            this.Availability = Availability;
            this.ProductionDate = ProductionDate;
            this.ImageAsBase64 = ImageAsBase64;
        }
    }

}
