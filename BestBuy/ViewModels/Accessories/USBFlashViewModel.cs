using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Accessories
{
    public class USBFlashViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public double? Price { get; set; }
        public int? MemoryCapacity { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string USBStandart { get; set; }
        public int? DataTransferRate { get; set; }
        public int? Availability { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string ImageAsBase64 { get; set; }
       


        public USBFlashViewModel()
        {
                
        }


        public USBFlashViewModel(string Name, string Brand, double? Price, int? MemoryCapacity, string Color, string Material, string USBStandart, 
                                 int? DataTransferRate, int? Availability, DateTime? ProductionDate, string ImageAsBase64)
        {
            this.Name = Name;
            this.Brand = Brand;
            this.Price = Price;
            this.MemoryCapacity = MemoryCapacity;
            this.Color = Color;
            this.Material = Material;
            this.USBStandart = USBStandart;
            this.DataTransferRate = DataTransferRate;
            this.Availability = Availability;
            this.ProductionDate = ProductionDate;
            this.ImageAsBase64 = ImageAsBase64;
        }
    }
}
