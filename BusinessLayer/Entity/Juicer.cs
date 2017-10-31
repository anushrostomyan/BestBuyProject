using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess;

namespace BusinessLayer.Entity
{
    public class Juicer
    {
        public int? ID { get; private set; }
        public string JuicerModel { get; private set; }
        public double? JuicerPower { get; private set; }
        public double? JuicerPrice { get; private set; }
        public byte? JuicerNumberOfSpeed { get; private set; }
        public double? JuicerVolme { get; private set; }
        public int? JuicerAvailability { get; private set; }
        public string JuicerColor { get; private set; }
        public DateTime? JuicerDate { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; private set; }

        public Juicer()
        {

        }

        public Juicer(int? ID = null, string JuicerModel = null, double? JuicerPower = null, double? JuicerPrice = null, byte? JuicerNumberOfSpeed = null,
                      double? JuicerVolme = null, int? JuicerAvailability = null, string JuicerColor = null, DateTime? JuicerDate = null, Status? Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.JuicerModel = JuicerModel;
            this.JuicerPower = JuicerPower;
            this.JuicerPrice = JuicerPrice;
            this.JuicerNumberOfSpeed = JuicerNumberOfSpeed;
            this.JuicerVolme = JuicerVolme;
            this.JuicerAvailability = JuicerAvailability;
            this.JuicerColor = JuicerColor;
            this.JuicerDate = JuicerDate;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;

        }

        private Juicer(Dictionary<string, object> elementDictionary)
        {
            this.ID = (int?)elementDictionary["ID"];
            this.JuicerModel = (string)elementDictionary["JuicerModel"];
            this.JuicerPower = (double?)elementDictionary["JuicerPower"];
            this.JuicerPrice = (double?)elementDictionary["JuicerPrice"];
            this.JuicerNumberOfSpeed = (byte?)elementDictionary["JuicerNumberOfSpeed"];
            this.JuicerVolme = (double?)elementDictionary["JuicerVolme"];
            this.JuicerAvailability = (int?)elementDictionary["JuicerAvailability"];
            this.JuicerColor = (string)elementDictionary["JuicerColor"];
            this.JuicerDate = (DateTime)elementDictionary["JuicerDate"];
            this.Status = (Status?)((byte)elementDictionary["Status"]);
            this.ImageAsBase64 = elementDictionary["Image"] != null ? Convert.ToBase64String((byte[])elementDictionary["Image"]) : null;
        }


        public List<Juicer> GetAllJuicers()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<Juicer> juicerList = new List<Juicer>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllJuicers", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        Juicer _juicer = new Juicer(item);
                        juicerList.Add(_juicer);
                    }
                }
                return juicerList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool? UpdateJuicerImage(byte[] imagebyte, int juicerID)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("juicerID", juicerID));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateJuicerImage", param);
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
