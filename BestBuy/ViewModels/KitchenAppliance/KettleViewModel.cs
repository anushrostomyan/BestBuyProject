using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.KitchenAppliance
{
    public class KettleViewModel
    {
        public string KettleModel { get; set; }
        public double? KettlePower { get; set; }
        public double? KettlePrice { get; set; }
        public double? KettleVolme { get; set; }
        public Filter? KettleFilter { get; set; }
        public int? KettleAvailability { get; set; }
        public string KettleColor { get; set; }
        public DateTime? KettleDate { get; set; }
        public string ImageAsBase64 { get; set; }

        public KettleViewModel()
        {

        }

        public KettleViewModel(string KettleModel = null, double? KettlePower = null, double? KettlePrice = null, double? KettleVolme = null, Filter? KettleFilter = null,
            int? KettleAvailability = null, string KettleColor = null, DateTime? KettleDate = null, string ImageAsBase64 = null)
        {

            this.KettleModel = KettleModel;
            this.KettlePower = KettlePower;
            this.KettlePrice = KettlePrice;
            this.KettleVolme = KettleVolme;
            this.KettleFilter = KettleFilter;
            this.KettleAvailability = KettleAvailability;
            this.KettleColor = KettleColor;
            this.KettleDate = KettleDate;
            this.ImageAsBase64 = ImageAsBase64;

        }
    }
}
