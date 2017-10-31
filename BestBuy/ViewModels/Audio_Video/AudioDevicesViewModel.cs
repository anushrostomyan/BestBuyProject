using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;

namespace BestBuy.ViewModels.Audio_Video
{
    public class AudioDevicesViewModel
    {
        public string Brand { get; set; }
        public string MadeInCountry { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public int? NumOfSpeakers { get; set; }
        public int? Frequency { get; set; }
        public int? USB { get; set; }
        public string RecordingSupport { get; set; }
        public bool? Bluetooth { get; set; }
        public string EchEffect { get; set; }
        public bool? CardReader { get; set; }
        public bool? FMRadio { get; set; }
        public bool? PlayingCD_R_RW { get; set; }
        public int? WarrantyYears { get; set; }
        public double? Price { get; set; }
        public string ImageAsBase64 { get; set; }

        public AudioDevicesViewModel()
        {

        }

        public AudioDevicesViewModel(string Brand, string MadeInCountry, DateTime? ProductionDate, string ModelName,
           string Color, int? NumOfSpeakers, int? Frequency, int? USB, string RecordingSupport, bool? Bluetooth,
            string EchEffect, bool? CardReader, bool? FMRadio, bool? PlayingCD_R_RW, 
            int? WarrantyYears, double? Price, string imageAsBase64)
        {
            this.Brand = Brand;
            this.MadeInCountry = MadeInCountry;
            this.ProductionDate = ProductionDate;
            this.ModelName = ModelName;
            this.Color = Color;
            this.NumOfSpeakers = NumOfSpeakers;
            this.Frequency = Frequency;
            this.USB = USB;
            this.RecordingSupport = RecordingSupport;
            this.Bluetooth = Bluetooth;
            this.EchEffect = EchEffect;
            this.CardReader = CardReader;
            this.FMRadio = FMRadio;
            this.PlayingCD_R_RW = PlayingCD_R_RW;
            this.WarrantyYears = WarrantyYears;
            this.Price = Price;
            this.ImageAsBase64 = imageAsBase64;

        }

    }
}
