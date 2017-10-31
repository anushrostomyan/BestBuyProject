using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;

namespace BusinessLayer.Entity
{
    public class FoodProcessor
    {
        public int? ID { get; private set; }
        public string FoodProcessorModel { get; private set; }
        public double? FoodProcessorPower { get; private set; }
        public double? FoodProcessorPrice { get; private set; }
        public byte? FoodProcessorNumberOfSpeed { get; private set; }
        public byte? FoodProcessorNumberOfFunction { get; private set; }
        public int? FoodProcessorAvailability { get; private set; }
        public string FoodProcessorColor { get; private set; }
        public DateTime? FoodProcessorDate { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; private set; }


        public FoodProcessor()
        {

        }

        public FoodProcessor(int? ID = null, string FoodProcessorModel = null, double? FoodProcessorPower = null,
                              double? FoodProcessorPrice = null, byte? FoodProcessorNumberOfSpeed = null, byte? FoodProcessorNumberOfFunction = null,
                              int? FoodProcessorAvailability = null, string FoodProcessorColor = null, DateTime? FoodProcessorDate = null, Status? Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.FoodProcessorModel = FoodProcessorModel;
            this.FoodProcessorPower = FoodProcessorPower;
            this.FoodProcessorPrice = FoodProcessorPrice;
            this.FoodProcessorNumberOfSpeed = FoodProcessorNumberOfSpeed;
            this.FoodProcessorNumberOfFunction = FoodProcessorNumberOfFunction;
            this.FoodProcessorAvailability = FoodProcessorAvailability;
            this.FoodProcessorColor = FoodProcessorColor;
            this.FoodProcessorDate = FoodProcessorDate;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;

        }

        private FoodProcessor(Dictionary<string, object> elementDictionary)
        {
            this.ID = (int?)elementDictionary["ID"];
            this.FoodProcessorModel = (string)elementDictionary["FoodProcessorModel"];
            this.FoodProcessorPower = (double)elementDictionary["FoodProcessorPower"];
            this.FoodProcessorPrice = (double?)elementDictionary["FoodProcessorPrice"];
            this.FoodProcessorNumberOfSpeed = (byte)elementDictionary["FoodProcessorNumberOfSpeed"];
            this.FoodProcessorNumberOfFunction = (byte)elementDictionary["FoodProcessorNumberOfFunction"];
            this.FoodProcessorAvailability = (int?)elementDictionary["FoodProcessorAvailability"];
            this.FoodProcessorColor = (string)elementDictionary["FoodProcessorColor"];
            this.FoodProcessorDate = (DateTime?)elementDictionary["FoodProcessorDate"];
            this.Status = (BusinessLayer.Enums.Status?)((byte)elementDictionary["Status"]);
            this.ImageAsBase64 = elementDictionary["Image"] != null ? Convert.ToBase64String((byte[])elementDictionary["Image"]) : null;
        }


        public List<FoodProcessor> GetAllFoodProcessors()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<FoodProcessor> foodprocList = new List<FoodProcessor>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllFoodProcessors", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        FoodProcessor _fp = new FoodProcessor(item);
                        foodprocList.Add(_fp);
                    }
                }
                return foodprocList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? UpdateFoodProcessorImage(byte[] imagebyte, int foodProcessorID)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("foodProcessorID", foodProcessorID));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateFoodProcessorImage", param);
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
