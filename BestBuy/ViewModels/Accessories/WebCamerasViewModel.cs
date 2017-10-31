using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Accessories
{
    public class WebCamerasViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public double? Price { get; set; }
        public string OS { get; set; }
        public double? CableLength { get; set; }
        public double? Mpix { get; set; }
        public int? Availability { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string ImageAsBase64 { get; set; }



        public WebCamerasViewModel()
        {
                
        }

        public WebCamerasViewModel(string Name, string Brand, double? Price, string OS, double? CableLength, double? Mpix, 
                                   int? Availability, DateTime? ProductionDate, string ImageAsBase64)
        {
            this.Name = Name;
            this.Brand = Brand;
            this.Price = Price;
            this.OS = OS;
            this.CableLength = CableLength;
            this.Mpix = Mpix;
            this.Availability = Availability;
            this.ProductionDate = ProductionDate;
            this.ImageAsBase64 = ImageAsBase64;
        }
    }
}
