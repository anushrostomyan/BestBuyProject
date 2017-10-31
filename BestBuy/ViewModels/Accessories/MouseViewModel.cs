using BestBuy.CommonModels.ExtensionMethods;
using BusinessLayer.Entity;
using BusinessLayer.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Accessories
{
    
    public class MouseViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public double? Price { get; set; }
        public string ConnectivityTechnology { get; set; }
        public int? Availability { get; set; }
        public string Color { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string ImageAsBase64 { get; set; }
                                       


        public MouseViewModel()
        {

        }


        public MouseViewModel(string Name, string Brand, double? Price, string ConnectivityTechnology,
                              int? Availability, string Color, DateTime? ProductionDate, string ImageAsBase64)
        {
            this.Name = Name;
            this.Brand = Brand;
            this.Price = Price;
            this.ConnectivityTechnology = ConnectivityTechnology;
            this.Availability = Availability;
            this.Color = Color;
            this.ProductionDate = ProductionDate;
            this.ImageAsBase64 = ImageAsBase64;
        }       
    }
    
}
