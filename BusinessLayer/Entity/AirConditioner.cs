using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class AirConditioner
    {
        public int? Id { get; private set; }
        public string Company { get; private set; }
        public string Name { get; private set; }
        public double? Price { get; private set; }
        public string WorkingSpace { get; private set; }
        public int? AirFlow { get; private set; }
        public string WorkingTemperature { get; private set; }
        public string ImageAsBase64 { get; private set; }

        public AirConditioner()
        {

        }

        public AirConditioner(int Id, string Name, string Company, string WorkingSpace,
                                int AirFlow, double Price, string WorkingTemperature, string ImageAsBase64 = null)
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
        private AirConditioner(Dictionary<string, object> element)
        {
            this.Id = (int?)element["Id"];
            this.Company = (string)element["Company"];
            this.Name = (string)element["Name"];
            this.Price = (double?)element["Price"];
            this.WorkingTemperature = (string)element["WorkingTemperature"];
            this.AirFlow = (int?)element["AirFlow"];
            this.WorkingSpace = (string)element["WorkingSpace"];
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;

        }

        public List<AirConditioner> GetAllAirConditioners()
        {
            try {
                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllAirConditioners", new List<SPParam>());
                List<AirConditioner> AirConditionerList = new List<AirConditioner>();
                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        AirConditioner _airConditioner = new AirConditioner(item);
                        AirConditionerList.Add(_airConditioner);
                    }
                }
                return AirConditionerList;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public bool? UpdateAirConditionerImage(byte[] imagebyte, int airConditionerId)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("airConditionerId", airConditionerId));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateAirConditionerImage", param);
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