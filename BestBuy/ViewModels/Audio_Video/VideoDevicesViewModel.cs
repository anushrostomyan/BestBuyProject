using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;

namespace BestBuy.ViewModels.Audio_Video
{
    public class VideoDevicesViewModel
    {

        public string Brand { get; set; }
        public string MadeInCountry { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int? Resolution { get; set; }
        public double? Diagonal { get; set; }
        public int? Brightness { get; set; }
        public string Support { get; set; }
        public string ModelName { get; set; }
        public string Videorecording { get; set; }
        public int? Availability { get; set; }
        public int? WarrantyYears { get; set; }
        public double? Price { get; set; }
        public string ImageAsBase64 { get; set; }


        public VideoDevicesViewModel()
        {

        }

        public VideoDevicesViewModel(string Brand, string MadeInCountry, DateTime? ProductionDat,
                            int? Resolution, double? Diagonal, int? Brightness, string Support, string ModelName,
                            string videorecording, int? Availability, int? WarrantyYears, double? Price, string imageAsBase64)
        {
            this.Brand = Brand;
            this.MadeInCountry = MadeInCountry;
            this.Availability = Availability;
            this.ProductionDate = ProductionDate;
            this.Resolution = Resolution;
            this.Diagonal = Diagonal;
            this.Brightness = Brightness;
            this.Support = Support;
            this.ModelName = ModelName;
            this.Videorecording = videorecording;
            this.WarrantyYears = WarrantyYears;
            this.Price = Price;
            this.ImageAsBase64 = imageAsBase64;

        }

    }
}
