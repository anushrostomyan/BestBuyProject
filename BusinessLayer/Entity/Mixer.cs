using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;

namespace BusinessLayer.Entity
{
    public class Mixer
    {
        public int? ID;
        public string MixerModel { get; private set; }
        public double? MixerPower { get; private set; }
        public double? MixerPrice { get; private set; }
        public byte? MixerNumberOfSpeed { get; private set; }
        public Bowel? MixerBowel { get; private set; }
        public int? MixerAvailability { get; private set; }
        public string MixerColor { get; private set; }
        public DateTime? MixerDate { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; private set; }

        public Mixer()
        {

        }

        public Mixer(int? ID = null, string MixerModel = null, double? MixerPower = null, double? MixerPrice = null, byte? MixerNumberOfSpeed = null, Bowel? MixerBowel = null,
           int? MixerAvailability = null, string MixerColor = null, DateTime? MixerDate = null, Status? Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.MixerModel = MixerModel;
            this.MixerPower = MixerPower;
            this.MixerPrice = MixerPrice;
            this.MixerNumberOfSpeed = MixerNumberOfSpeed;
            this.MixerBowel = MixerBowel;
            this.MixerAvailability = MixerAvailability;
            this.MixerColor = MixerColor;
            this.MixerDate = MixerDate;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;
        }
        private Mixer(Dictionary<string, object> elemantDictionary)
        {
            this.ID = (int?)elemantDictionary["ID"];
            this.MixerModel = (string)elemantDictionary["MixerModel"];
            this.MixerPower = (double?)elemantDictionary["MixerPower"];
            this.MixerPrice = (double?)elemantDictionary["MixerPrice"];
            this.MixerNumberOfSpeed = (byte?)elemantDictionary["MixerNumberOfSpeed"];
            this.MixerBowel = (Bowel?)(byte)elemantDictionary["MixerBowel"];
            this.MixerAvailability = (int?)elemantDictionary["MixerAvailability"];
            this.MixerColor = (string)elemantDictionary["MixerColor"];
            this.MixerDate = (DateTime?)elemantDictionary["MixerDate"];
            this.Status = (Status?)((byte)elemantDictionary["Status"]);
            this.ImageAsBase64 = elemantDictionary["Image"] != null ? Convert.ToBase64String((byte[])elemantDictionary["Image"]) : null;

        }

        public List<Mixer> GetAllMixers()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<Mixer> mixerList = new List<Mixer>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllMixers", new List<SPParam>());
                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        Mixer _mixer = new Mixer(item);
                        mixerList.Add(_mixer);
                    }

                }
                return mixerList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? UpdateMixerImage(byte[] imagebyte, int mixerID)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("mixerID", mixerID));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateMixerImage", param);
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
