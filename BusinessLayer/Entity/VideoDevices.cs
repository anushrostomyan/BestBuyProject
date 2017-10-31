using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;


namespace BusinessLayer.Entity
{
    public class VideoDevices
    {
        public int? ID { get; private set; }
        public string Brand { get; private set; }
        public string MadeInCountry { get; private set; }
        public DateTime? ProductionDate { get; private set; }
        public int? Resolution { get; private set; }
        public double? Diagonal { get; private set; }
        public int? Brightness { get; private set; }
        public string Support { get; private set; }
        public string ModelName { get; private set; }
        public string Videorecording { get; private set; }
        public int? Availability { get; private set; }
        public int? WarrantyYears { get; private set; }
        public double? Price { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; private set; }


        public VideoDevices()
        {

        }

        public VideoDevices(int? ID = null, string Brand = null, string MadeInCountry = null, DateTime? ProductionDat = null,
                            int? Resolution = null, double? Diagonal = null, int? Brightness = null, string Support = null, string ModelName = null,
                            string videorecording = null, int? Availability = null, int? WarrantyYears = null, double? Price = null, Status? Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.Brand = Brand;
            this.MadeInCountry = MadeInCountry;
            this.Availability = Availability;
            this.ProductionDate = ProductionDate;
            this.Resolution = Resolution;
            this.Diagonal = Diagonal;
            this.Brightness = Brightness;
            this.Support = Support;
            this.ModelName = ModelName;
            this.Videorecording = videorecording;
            this.WarrantyYears = WarrantyYears;
            this.Price = Price;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;

        }
        private VideoDevices(Dictionary<string, object> element)
        {
            this.ID = (int?)element["ID"];
            this.Brand = (string)element["Brand"];
            this.MadeInCountry = (string)element["MadeInCountry"];
            this.Availability = (int?)element["Availability"];
            this.ProductionDate = ProductionDate;
            this.Resolution = (int?)element["Resolution"];
            this.Diagonal = (int?)element["Diagonal"];
            this.Brightness = (int?)element["Brightness"];
            this.ModelName = (string)element["ModelName"];
            this.Support = (string)element["Support"];
            this.Videorecording = (string)element["Videorecording"];
            this.WarrantyYears = (int?)element["WarrantyYears"];
            this.Price = (double?)element["Price"];
            this.Status = (BusinessLayer.Enums.Status?)element["Status"];
            this.ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;

        }


        public List<VideoDevices> GetAllVideoDevices()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<VideoDevices> VideoDevicesList = new List<VideoDevices>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllVideoDevices", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        VideoDevices _videoDevices = new VideoDevices(item);
                        VideoDevicesList.Add(_videoDevices);
                    }
                }
                return VideoDevicesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool? UpdateVideoDevicesImage(byte[] imagebyte, int videoDeviceId)
        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("videoDeviceId", videoDeviceId));
                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateVideoDevicesImage", param);
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
