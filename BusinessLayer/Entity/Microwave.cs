using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess;

namespace BusinessLayer.Entity
{
    public class Microwave
    {
        public int? ID { get; private set; }
        public string MicrowaveModel { get; private set; }
        public double? MicrowavePower { get; private set; }
        public double? MicrowaveVolme { get; private set; }
        public double? MicrowavePrice { get; private set; }
        public int? MicrowaveAvailability { get; private set; }
        public string MicrowaveColor { get; private set; }
        public DateTime? MicrowaveDate { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; private set; }

        public Microwave()
        {

        }

        public Microwave(int? ID = null, string MicrowaveModel = null, double? MicrowavePower = null, double? MicrowaveVolme = null, double? MicrowavePrice = null,
            int? MicrowaveAvailability = null, string MicrowaveColor = null, DateTime? MicrowaveDate = null, Status? Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.MicrowaveModel = MicrowaveModel;
            this.MicrowavePower = MicrowavePower;
            this.MicrowaveVolme = MicrowaveVolme;
            this.MicrowavePrice = MicrowavePrice;
            this.MicrowaveAvailability = MicrowaveAvailability;
            this.MicrowaveColor = MicrowaveColor;
            this.MicrowaveDate = MicrowaveDate;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;

        }

        private Microwave(Dictionary<string, object> elemantDictionary)
        {
            this.ID = (int?)elemantDictionary["ID"];
            this.MicrowaveModel = (string)elemantDictionary["MicrowavesModel"];
            this.MicrowavePower = (double?)elemantDictionary["MicrowavesPower"];
            this.MicrowaveVolme = (double?)elemantDictionary["MicrowavesVolme"];
            this.MicrowavePrice = (double?)elemantDictionary["MicrowavePrice"];
            this.MicrowaveAvailability = (int?)elemantDictionary["MicrowaveAvailability"];
            this.MicrowaveColor = (string)elemantDictionary["MicrowavesColor"];
            this.MicrowaveDate = (DateTime?)elemantDictionary["MicrowaveDate"];
            this.Status = (Status?)((byte)elemantDictionary["Status"]);
            this.ImageAsBase64 = elemantDictionary["Image"] != null ? Convert.ToBase64String((byte[])elemantDictionary["Image"]) : null;

        }

        public List<Microwave> GetAllMicrowaves()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<Microwave> microwaveList = new List<Microwave>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllMicrowaves", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        Microwave _microwave = new Microwave(item);
                        microwaveList.Add(_microwave);
                    }
                }
                return microwaveList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool? UpdateMicrowaveImage(byte[] imagebyte, int microwaveID)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("microwaveID", microwaveID));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateMicrowaveImage", param);
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
