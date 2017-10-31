using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class WebCameras
    {
        public int? ID { get; private set; }
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public double? Price { get; private set; }
        public string OS { get; private set; }
        public double? CableLength { get; private set; }
        public double? Mpix { get; private set; }
        public int? Availability { get; private set; }
        public DateTime? PruductionDate { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; set; }


        public WebCameras()
        {

        }
        public WebCameras(int? ID = null, string Name = null, string Brand = null, double? Price = null,
                         string OS = null, double? CableLength = null, double? Mpix = null,
                         int? Availablity = null, DateTime? ProductionDate = null, Status? Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.Name = Name;
            this.Brand = Brand;
            this.Price = Price;
            this.OS = OS;
            this.CableLength = CableLength;
            this.Mpix = Mpix;
            this.Availability = Availability;
            this.PruductionDate = PruductionDate;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;
        }

        private WebCameras(Dictionary<string, object> element)
        {
            ID = (int?)element["ID"];
            Name = (string)element["Name"];
            Brand = (string)element["Brand"];
            Price = (double?)element["Price"];
            OS = (string)element["OS"];
            CableLength = (double?)element["CableLength"];
            Mpix = (double?)element["Mpix"];
            Availability = (int?)element["Availability"];
            PruductionDate = (DateTime?)element["ProductionDate"];
            Status = (BusinessLayer.Enums.Status)((byte)element["Status"]);
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;
        }


        public List<WebCameras> GetAllWebCameras()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<WebCameras> webcamerasList = new List<WebCameras>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllCameras", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        WebCameras _webCameras = new WebCameras(item);
                        webcamerasList.Add(_webCameras);
                    }

                }

                return webcamerasList;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool? UpdateWebCamerasImage(byte[] imagebyte, int webcameraId)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("webcameraid", webcameraId));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateWebCameraImage", param);
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
