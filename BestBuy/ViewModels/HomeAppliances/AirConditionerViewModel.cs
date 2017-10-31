using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.HomeAppliances
{
    public class AirConditionerViewModel
    {
        public int? Id { get;  set; }
        public string Company { get;  set; }
        public string Name { get;  set; }
        public double? Price { get;  set; }
        public string WorkingSpace { get;  set; }
        public int? AirFlow { get;  set; }
        public string WorkingTemperature { get;  set; }
        public string ImageAsBase64 { get; set; }


        public AirConditionerViewModel(int? Id, string Company, string Name, double? Price, string WorkingSpace,
                        int? AirFlow, string WorkingTemperature, string ImageAsBase64)
        {
            this.Id = Id;
            this.Price = Price;
            this.Company = Company;
            this.Name = Name;
            this.AirFlow = AirFlow;
            this.WorkingSpace = WorkingSpace;
            this.WorkingTemperature = WorkingTemperature;
            this.ImageAsBase64 = ImageAsBase64;
        }

    }
}
