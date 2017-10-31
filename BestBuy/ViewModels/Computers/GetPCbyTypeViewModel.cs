using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Computers
{
    public class GetPCbyTypeViewModel
    {
        public int? ID { get; private set; }
        public string ProductName { get; private set; }
        public double? Price { get; private set; }
        public double? ScreenSize { get; private set; }
        public string ScreenResolution { get; private set; }
        public string TouchScreen { get; private set; }
        public string Color { get; private set; }
        public string CPU { get; private set; }
        public int? RAM { get; private set; }
        public int? HDD { get; private set; }
        public int? SSD { get; private set; }
        public string OS { get; private set; }
        public double? Weight { get; private set; }
        public string WebCam { get; private set; }
        public string GraphicsCard { get; private set; }
        public Availability? Availability { get; private set; }
        public PCType? TypeOfPC { get; private set; }

        public GetPCbyTypeViewModel(int? ID = null, string ProductName = null, double? Price = null,
                 double? ScreenSize = null, string ScreenResolution = null, string TouchScreen = null,
                 string Color = null, string CPU = null, short? RAM = null, short? HDD = null, short? SSD = null,
                  string OS = null, string GraphicsCard = null, string WebCam = null,
                  double? Weight = null, Availability? Availability = null, PCType? TypeOfPC = null)
        {
            this.ID = ID;
            this.ProductName = ProductName;
            this.Price = Price;
            this.ScreenSize = ScreenSize;
            this.ScreenResolution = ScreenResolution;
            this.TouchScreen = TouchScreen;
            this.Color = Color;
            this.CPU = CPU;
            this.RAM = RAM;
            this.HDD = HDD;
            this.SSD = SSD;
            this.OS = OS;
            this.GraphicsCard = GraphicsCard;
            this.WebCam = WebCam;
            this.Weight = Weight;
            this.Availability = Availability;
            this.TypeOfPC = TypeOfPC;
            
        }

    }
}
