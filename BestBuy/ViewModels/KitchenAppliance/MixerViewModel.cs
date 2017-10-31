using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.KitchenAppliance
{
    public class MixerViewModel
    {
        public string MixerModel { get; set; }
        public double? MixerPower { get; set; }
        public double? MixerPrice { get; set; }
        public byte? MixerNumberOfSpeed { get; set; }
        public Bowel? MixerBowel { get; set; }
        public int? MixerAvailability { get; set; }
        public string MixerColor { get; set; }
        public DateTime? MixerDate { get; set; }
        public Status? Status { get; set; }
        public string ImageAsBase64 { get; set; }

        public MixerViewModel()
        {

        }

        public MixerViewModel(string MixerModel = null, double? MixerPower = null, double? MixerPrice = null, byte? MixerNumberOfSpeed = null, Bowel? MixerBowel = null,
           int? MixerAvailability = null, string MixerColor = null, DateTime? MixerDate = null, string ImageAsBase64 = null)
        {
            this.MixerModel = MixerModel;
            this.MixerPower = MixerPower;
            this.MixerPrice = MixerPrice;
            this.MixerNumberOfSpeed = MixerNumberOfSpeed;
            this.MixerBowel = MixerBowel;
            this.MixerAvailability = MixerAvailability;
            this.MixerColor = MixerColor;
            this.MixerDate = MixerDate;
            this.ImageAsBase64 = ImageAsBase64;

        }

    }
}
