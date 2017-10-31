using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;


namespace BusinessLayer.Entity
{
    public class AudioDevices
    {
        public int? ID { get; private set; }
        public string Brand { get; private set; }
        public string MadeInCountry { get; private set; }
        public DateTime? ProductionDate { get; private set; }
        public string ModelName { get; private set; }
        public string Color { get; private set; }
        public int? NumOfSpeakers { get; private set; }
        public int? Frequency { get; private set; }
        public int? USB { get; private set; }
        public string RecordingSupport { get; private set; }
        public bool? Bluetooth { get; private set; }
        public string EchEffect { get; private set; }
        public bool? CardReader { get; private set; }
        public bool? FMRadio { get; private set; }
        public bool? PlayingCD_R_RW { get; private set; }
        public int? WarrantyYears { get; private set; }
        public double? Price { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; private set; }

        public AudioDevices()
        {

        }

        public AudioDevices(int? ID = null, string Brand = null, string MadeInCountry = null, DateTime? ProductionDate = null, string ModelName = null,
           string Color = null, int? NumOfSpeakers = null, int? Frequency = null, int? USB = null, string RecordingSupport = null, bool? Bluetooth = null,
            string EchEffect = null, bool? CardReader = null, bool? FMRadio = null, bool? PlayingCD_R_RW = null,
            int? WarrantyYears = null, double? Price = null, Status? Status = null, string ImageAsBase64=null)
        {
            this.ID = ID;
            this.Brand = Brand;
            this.MadeInCountry = MadeInCountry;
            this.ProductionDate = ProductionDate;
            this.ModelName = ModelName;
            this.Color = Color;
            this.NumOfSpeakers = NumOfSpeakers;
            this.Frequency = Frequency;
            this.USB = USB;
            this.RecordingSupport = RecordingSupport;
            this.Bluetooth = Bluetooth;
            this.EchEffect = EchEffect;
            this.CardReader = CardReader;
            this.FMRadio = FMRadio;
            this.PlayingCD_R_RW = PlayingCD_R_RW;
            this.WarrantyYears = WarrantyYears;
            this.Price = Price;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;
        }
        private AudioDevices(Dictionary<string, object> element)
        {
            this.ID = (int?)element["ID"];
            this.Brand = (string)element["Brand"];
            this.MadeInCountry = (string)element["MadeInCountry"];
            this.ProductionDate = (DateTime?)element["ProductionDate"];
            this.ModelName = (string)element["ModelName"];
            this.Color = (string)element["Color"];
            this.NumOfSpeakers = (int?)element["NumOfSpeakers"];
            this.Frequency = (int?)element["Frequency"];
            this.USB = (int?)element["USB"];
            this.RecordingSupport = (string)element["RecordingSupport"];
            this.Bluetooth = (bool)element["Bluetooth"];
            this.EchEffect = (string)element["EchEffect"];
            this.CardReader = (bool?)element["CardReader"];
            this.FMRadio = (bool)element["FMRadio"];
            this.PlayingCD_R_RW = (bool)element["PlayingCD_R_RW"];
            this.WarrantyYears = (int?)element["WarrantyYears"];
            this.Price = (double?)element["Price"];
            this.Status = (BusinessLayer.Enums.Status?)(byte)element["Status"];
            this.ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;

        }


        public List<AudioDevices> GetAllAudioDevices()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<AudioDevices> deviceList = null;
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllAudioDevices", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    deviceList = new List<AudioDevices>(result.Count);

                    foreach (Dictionary<string, object> item in result)
                    {
                        AudioDevices _audioDevices = new AudioDevices(item);
                        deviceList.Add(_audioDevices);
                    }
                }
                return deviceList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool? UpdateAudioDevicesImage(byte[] imagebyte, int audioDeviceId)
        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("audioDeviceId", audioDeviceId));
                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateAudioDevicesImage", param);
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
