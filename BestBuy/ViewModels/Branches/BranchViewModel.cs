using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Branches
{
    public class BranchViewModel
    {
        //public double? X_Coordinate { get; private set; }
        //public double? Y_Coordinate { get; private set; }
        //public string Address { get; private set; }
        //public string Name { get; private set; }
        //public string PhoneNumber { get; private set; }
        //public string WorkingHours { get; private set; }
        //public string District { get; private set; }

        public double? X_Coordinate { get; set; }
        public double? Y_Coordinate { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkingHours { get; set; }
        public string District { get; set; }

        public BranchViewModel(double? x_coordinate, double? y_coordinate,
                               string address, string name, string phoneNumber,
                               string workingHours, string district)
        {
            this.X_Coordinate = x_coordinate;
            this.Y_Coordinate = y_coordinate;
            this.Address = address;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.WorkingHours = workingHours;
            this.District = district;
        }
    }


   
}
