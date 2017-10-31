
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Entity
{
    public class Mouse
    {
        public int? ID { get; private set; }
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public double? Price { get; private set; }
        public string ConnectivityTechnology { get; private set; }
        public int? Availability { get; private set; }
        public string Color { get; private set; }
        public DateTime? ProductionDate { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; private set; }



        public Mouse()
        {

        }



        public Mouse(int? ID = null, string Name = null,string Brand = null,
                     double? Price = null, string ConnectivityTechnology = null, int? Availability = null,
                     string Color = null, DateTime? ProductionDate = null, Status? 
                     Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.Name = Name;
            this.Brand = Brand;
            this.Price = Price ;
            this.ConnectivityTechnology =  ConnectivityTechnology;
            this.Availability = Availability;
            this.Color = Color;
            this.ProductionDate = ProductionDate;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;
        }

        private Mouse(Dictionary<string,object> element)
        {
            this.ID = (int?)element["ID"];
            this.Name = (string)element["Name"];
            this.Brand = (string)element["Brand"];
            Price = (double?)element["Price"];
            Color = (string)element["Color"];
            ConnectivityTechnology = (string)element["ConnectivityTechnology"];
            ProductionDate = (DateTime?)element["ProductionDate"];
            Availability = (int?)element["Availability"];
            Status = (BusinessLayer.Enums.Status?)((byte)element["Status"]);
            ImageAsBase64 = element["Image"] != null? Convert.ToBase64String((byte[])element["Image"]) : null;
        }


        public List<Mouse> GetAllMouses()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<Mouse> mouseList = new List<Mouse>();
                List<Dictionary<string,object>> result = db.ExecuteStoredProcedure("GetAllMouses", new List<SPParam>());
              
                if(result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        Mouse _mouse = new Mouse(item);
                        mouseList.Add(_mouse);
                    }
                }
                return mouseList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? UpdateMouseImage(byte[] imagebyte, int mouseId)

        {
            try
            {
               
                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("mouseId", mouseId));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateMouseImage", param);
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
