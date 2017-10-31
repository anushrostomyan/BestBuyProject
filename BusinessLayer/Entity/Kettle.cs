using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess;

namespace BusinessLayer.Entity
{
    public class Kettle
    {

        //public string KettleModel { get; private set; }
        public int? ID { get; private set; }
        public string KettleModel { get; private set; }
        public double? KettlePower { get; private set; }
        public double? KettlePrice { get; private set; }
        public double? KettleVolme { get; private set; }
        public Filter? KettleFilter { get; private set; }
        public int? KettleAvailability { get; private set; }
        public string KettleColor { get; private set; }
        public DateTime? KettleDate { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; private set; }

        public Kettle()
        {

        }

        public Kettle(int? ID = null, string KettleModel = null, double? KettlePower = null, double? KettlePrice = null, double? KettleVolme = null, Filter? KettleFilter = null,
            int? KettleAvailability = null, string KettleColor = null, DateTime? KettleDate = null, Status? Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.KettleModel = KettleModel;
            this.KettlePower = KettlePower;
            this.KettlePrice = KettlePrice;
            this.KettleVolme = KettleVolme;
            this.KettleFilter = KettleFilter;
            this.KettleAvailability = KettleAvailability;
            this.KettleColor = KettleColor;
            this.KettleDate = KettleDate;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;

        }

        private Kettle(Dictionary<string, object> elementDictionary)
        {
            this.ID = (int?)elementDictionary["ID"];
            this.KettleModel = (string)elementDictionary["KettleModel"];
            this.KettlePower = (double?)elementDictionary["KettlePower"];
            this.KettlePrice = (double?)elementDictionary["KettlePrice"];
            this.KettleVolme = (double?)elementDictionary["KettleVolme"];
            this.KettleFilter = (Filter?)((byte)elementDictionary["KettleFilter"]);
            this.KettleAvailability = (int?)elementDictionary["KettleAvailability"];
            this.KettleColor = (string)elementDictionary["KettleColor"];
            this.KettleDate = (DateTime?)elementDictionary["KettleDate"];
            this.Status = (Status?)((byte)elementDictionary["Status"]);
            this.ImageAsBase64 = elementDictionary["Image"] != null ? Convert.ToBase64String((byte[])elementDictionary["Image"]) : null;
        }

        public List<Kettle> GetAllKettles()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<Kettle> kettleList = new List<Kettle>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllKettles", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        Kettle _kettle = new Kettle(item);
                        kettleList.Add(_kettle);
                    }
                }
                return kettleList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? UpdateKettleImage(byte[] imagebyte, int kettleID)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("kettleID", kettleID));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateKettleImage", param);
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
