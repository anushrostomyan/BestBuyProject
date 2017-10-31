using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class USB_Flash
    {
        public int? ID { get; private set; }
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public double? Price { get; private set; }
        public int? MemoryCapacity { get; private set; }
        public string Color { get; private set; }
        public string Material { get; private set; }
        public string USBStandard { get; private set; }
        public int? DataTransferRate { get; private set; }
        public DateTime? ProductionDate { get; private set; }
        public int? Availability { get; private set; }
        public Status? Status { get; private set; }
        public string ImageAsBase64 { get; set; }


        public USB_Flash()
        {

        }


        public USB_Flash(int? ID = null, string Name = null, string Material = null,
                          double? Price = null, int? MemoryCapacity = null, string Color = null,
                          string USBStandard = null, int? DataTransferRate = null, DateTime? ProductionDAte = null,
                          int? Availablity = null, Status? Status = null, string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.Name = Name;
            this.Brand = Brand;
            this.Price = Price;
            this.MemoryCapacity = MemoryCapacity;
            this.Color = Color;
            this.Material = Material;
            this.USBStandard = USBStandard;
            this.DataTransferRate = DataTransferRate;
            this.ProductionDate = ProductionDate;
            this.Availability = Availability;
            this.Status = Status;
            this.ImageAsBase64 = ImageAsBase64;
        }

        private USB_Flash(Dictionary<string, object> element)
        {
            this.ID = (int?)element["ID"];
            this.Name = (string)element["Name"];
            this.Brand = (string)element["Brand"];
            Price = (double?)element["Price"];
            MemoryCapacity = (int?)element["MemoryCapacity"];
            Color = (string)element["Color"];
            Material = (string)element["Material"];
            USBStandard = (string)element["USBStandard"];
            DataTransferRate = (int?)element["DataTransferRate"];
            ProductionDate = (DateTime?)element["ProductionDate"];
            Availability = (int?)element["Availability"];
            Status = (BusinessLayer.Enums.Status?)((byte)element["Status"]);
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;
        }

        public List<USB_Flash> GetAllUSB_Flash()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<USB_Flash> USB_FlashList = new List<USB_Flash>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllUSB_Flash", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        USB_Flash _usb_flash = new USB_Flash(item);
                        USB_FlashList.Add(_usb_flash);
                    }
                }
                return USB_FlashList;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? UpdateUSBFlashImage(byte[] imagebyte, int usbflashId)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("usbflashId", usbflashId));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateUSBFlashImage", param);
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
