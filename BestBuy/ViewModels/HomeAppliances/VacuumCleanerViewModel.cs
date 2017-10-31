using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.HomeAppliances
{
    public class VacuumCleanerViewModel
    {
        public int? Id { get;  set; }
        public string Company { get;  set; }
        public string Name { get;  set; }
        public double? Price { get;  set; }
        public int? MaximumPower { get;  set; }
        public int? SuctionPower { get;  set; }
        public double? DustBagCapacity { get;  set; }
        public string ImageAsBase64 { get; set; }

        public VacuumCleanerViewModel(int? Id, string Company, string Name, double? Price, int? MaximumPower,
                        int? SuctionPower, double? DustBagCapacity, string ImageAsBase64)
        {
            this.Id = Id;
            this.Price = Price;
            this.Company = Company;
            this.Name = Name;
            this.MaximumPower = MaximumPower;
            this.SuctionPower = SuctionPower;
            this.DustBagCapacity = DustBagCapacity;
            this.ImageAsBase64 = ImageAsBase64;
        }



    }
}
