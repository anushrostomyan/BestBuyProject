using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.HomeAppliances
{
    public class FreezerViewModel
    {
        public int? Id { get;  set; }
        public string Company { get;  set; }
        public string Name { get;  set; }
        public double? Price { get;  set; }
        public int? NumberOfDoors { get;  set; }
        public double? TotalCapacity { get;  set; }
        public string Dimensions { get;  set; }
        public string Colour { get;  set; }
        public string ImageAsBase64 { get; set; }

        public FreezerViewModel(int? Id, string Company, string Name, double? Price, string Colour,
                  string Dimensions, int? NumberOfDoors, double? TotalCapacity, string ImageAsBase64)
        {
            this.Id = Id;
            this.Price = Price;
            this.Company = Company;
            this.Name = Name;
            this.Colour = Colour;
            this.Dimensions = Dimensions;
            this.NumberOfDoors = NumberOfDoors;
            this.TotalCapacity = TotalCapacity;
            this.ImageAsBase64 = ImageAsBase64;
        }

    }  
}
