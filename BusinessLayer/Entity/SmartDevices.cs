using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class SmartDevices
    {
        public int? ID { get; private set; }
        public string Name { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public double? Price { get; private set; }
        public double? SIZE { get; private set; }
        public string SIM { get; private set; }
        public int? MEMORY { get; private set; }
        public double? CAMERA { get; private set; }
        public string CPU { get; private set; }
        public int? BATTERY { get; private set; }
        public MobTabEnums? MobTabType { get; private set; }
        public string ImageAsBase64 { get; private set; }

        public SmartDevices()
        {

        }

        public SmartDevices(MobTabEnums enums)
        {
            MobTabType = enums;
        }

        public SmartDevices(int? ID = null, string name = null, string model = null, string color = null,
            double? price = null, double? size = null, string sim = null, int? memory = null,
            double? camera = null, string cpu = null, int? battery = null, MobTabEnums? mobTabType = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.Name = name;
            this.Model = model;
            this.Color = color;
            this.Price = price;
            this.SIZE = size;
            this.SIM = sim;
            this.MEMORY = memory;
            this.CAMERA = camera;
            this.CPU = cpu;
            this.BATTERY = battery;
            this.MobTabType = mobTabType;
            this.ImageAsBase64 = ImageAsBase64;
        }

        private SmartDevices(Dictionary<string, object> element)
        {
            ID = (int?)element["ID"];
            Name = (string)element["Name"];
            Model = (string)element["Model"];
            Color = (string)element["Color"];
            Price = (double?)element["Price"];
            SIZE = (double?)element["SIZE"];
            SIM = (string)element["SIM"];
            MEMORY = (int?)element["MEMORY"];
            CAMERA = (double?)element["CAMERA"];
            CPU = (string)element["CPU"];
            BATTERY = (int?)element["BATTERY"];
            MobTabType = (MobTabEnums?)(byte?)element["MobTabType"];
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;
        }

        public List<SmartDevices> GetAllSmartDevices()
        {
            List<SmartDevices> SDlist = null;
            try
            {
                DbDataAccess db = new DbDataAccess();

                List<SPParam> par = new List<SPParam>();
                par.Add(new SPParam("typeID", (byte)this.MobTabType));
                List <Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllSmartDevices", par);

                if (result != null && result.Count != 0)
                {
                    SDlist = new List<SmartDevices>(result.Count);
                    foreach (var item in result)
                    {
                        SmartDevices _smartDevices = new SmartDevices(item);
                        SDlist.Add(_smartDevices);
                    }
                }
                return SDlist;

            }
            catch (Exception ex)
            {
                return SDlist;
            }
        }

        public bool? UpdateSmartDevicesImage(byte[] imagebyte, int SDveId)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("SDveId", SDveId));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateSmartDevicesImage", param);
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
