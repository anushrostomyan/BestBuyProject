using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class Keyboards
    {
        public int? ID { get; private set; }
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public string Color { get; private set; }
        public int? NumberOfKeys { get; private set; }
        public string OS { get; private set; }
        public double? Price { get; private set; }
        public string ConnectionTechnology { get; private set; }
        public int? Availability { get; private set; }
        public DateTime? ProductionDate { get; set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; set; }


        public Keyboards()
        {

        }


        public Keyboards( int? ID = null, string Name = null, string Brand = null, string Color = null,
                         int? NumberOfKeys = null, string OS = null, double? Price = null, string ConnectionTechnology = null,
                         int? Availablity = null, Status? Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.Name = Name;
            this.Brand = Brand;
            this.Color = Color;
            this.NumberOfKeys = NumberOfKeys;
            this.OS = OS;
            this.Price = Price;
            this.ConnectionTechnology = ConnectionTechnology;
            this.Availability = Availablity;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;
        }


        private Keyboards(Dictionary<string, object> element)
        {
            ID = (int?)element["ID"];
            Name = (string)element["Name"];
            Brand = (string)element["Brand"];
            Color = (string)element["Color"];
            NumberOfKeys = (int?)element["NumberOfKeys"];
            OS = (string)element["OS"];
            Price = (double?)element["Price"];
            ConnectionTechnology = (string)element["ConnectionTechnology"];
            Availability = (int?)element["Availability"];
            Status = (BusinessLayer.Enums.Status)((byte)element["Status"]);
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;
        }

        public List<Keyboards> GetAllKeyboards()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<Keyboards> keyboardList = null;
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllKeyboards", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    keyboardList = new List<Keyboards>(result.Count);
                    foreach (var item in result)
                    {
                        Keyboards keyboards = new Keyboards(item);
                        keyboardList.Add(keyboards);
                    }
                }

                return keyboardList;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? UpdateKeyboardsImage(byte[] imagebyte, int keyboardId)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("keyboardsId", keyboardId));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateKeyboardsImage", param);
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
