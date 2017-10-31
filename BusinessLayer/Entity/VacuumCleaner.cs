using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class VacuumCleaner
    {
        public int? Id { get; private set; }
        public string Company { get; private set; }
        public string Name { get; private set; }
        public double? Price { get; private set; }
        public int? MaximumPower { get; private set; }
        public int? SuctionPower { get; private set; }
        public double? DustBagCapacity { get; private set; }
        public string ImageAsBase64 { get; private set; }

        public VacuumCleaner()
        {
                
        }

        public VacuumCleaner(int Id, string Company, string Name, double Price, int MaximumPower,
                                int SuctionPower, double DustBagCapacity,string ImageAsBase64 = null)
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
        private VacuumCleaner(Dictionary<string, object> element)
        {
            this.Id = (int?)element["Id"];
            this.Price = (double?)element["Price"];
            this.Company = (string)element["Company"];
            this.Name = (string)element["Name"];
            this.MaximumPower = (int?)element["MaximumPower"];
            this.SuctionPower = (int?)element["SuctionPower"];
            this.DustBagCapacity = (double?)element["DustBagCapacity"];
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;
        }
        public List<VacuumCleaner> GetAllVacuumCleaners()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllVacuumCleaners", new List<SPParam>());
                List<VacuumCleaner> vacuumCleanerList = new List<VacuumCleaner>();

                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        VacuumCleaner _vacuumCleaner = new VacuumCleaner(item);
                        vacuumCleanerList.Add(_vacuumCleaner);
                    }
                }
                return vacuumCleanerList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool? UpdateVacuumCleanerImage(byte[] imagebyte, int vacuumCleanerId)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("vacuumCleanerId", vacuumCleanerId));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateVacuumCleanerImage", param);
                if (result != null && result.Count != 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}