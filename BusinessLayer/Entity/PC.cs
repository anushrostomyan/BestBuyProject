using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;

namespace BusinessLayer.Entity
{
    public class PC
    {
        public int? ID { get; private set; }
        public string ProductName { get; private set; }
        public double? Price { get; private set; }
        public double? ScreenSize { get; private set; }
        public string ScreenResolution { get; private set; }
        public string TouchScreen { get; private set; }
        public string Color { get; private set; }
        public string CPU { get; private set; }
        public short? RAM { get; private set; }
        public short? HDD { get; private set; }
        public short? SSD { get; private set; }
        public string OS { get; private set; }
        public double? Weight { get; private set; }
        public string WebCam { get; private set; }
        public string GraphicsCard { get; private set; }
        public Availability? Availability { get; private set; }
        public PCType? TypeOfPC { get; private set; }
        public Status? Status { get; private set; }

        public PC()
        {

        }
        
        public PC(int? ID = null,string ProductName = null,double? Price = null, 
                  double? ScreenSize = null, string ScreenResolution = null,string TouchScreen = null,
                  string Color = null,string CPU = null, short? RAM = null, short? HDD = null, short? SSD = null,
                   string OS = null, string GraphicsCard = null,string WebCam = null,
                   double? Weight = null, Availability? Availability = null, PCType? TypeOfPC = null, Status? Status = null)
        {
            this.ID = ID;
            this.ProductName = ProductName;
            this.Price = Price;
            this.ScreenSize = ScreenSize;
            this.ScreenResolution = ScreenResolution;
            this.TouchScreen = TouchScreen;
            this.Color = Color;
            this.CPU = CPU;
            this.RAM = RAM;
            this.HDD = HDD;
            this.SSD = SSD;
            this.OS = OS;
            this.GraphicsCard = GraphicsCard;
            this.WebCam = WebCam;
            this.Weight = Weight;
            this.Availability = Availability;
            this.TypeOfPC = TypeOfPC;
            this.Status = Status;
        }

        private PC(Dictionary<string,object> element)
        {
            ID = (int?) element["ID"];
            ProductName = (string)element["ProductName"];
            Price = (double?)element["Price"];
            ScreenSize = (double?)element["ScreenSize"];
            ScreenResolution = (string)element["ScreenResolution"];
            TouchScreen = (string)element["TouchScreen"];
            Color = (string)element["Color"];
            CPU = (string)element["CPU"];
            RAM = (short?)element["RAM"];
            HDD = (short?)element["HDD"];
            SSD = (short?)element["SSD"];
            OS = (string)element["OS"];
            GraphicsCard = (string)element["GraphicsCard"];
            WebCam = (string)element["WebCam"];
            Weight = (double?)element["Weight"];
            Availability = (BusinessLayer.Enums.Availability?)(byte?)element["Availability"];
            TypeOfPC = (BusinessLayer.Enums.PCType?)(byte?)element["PCType"];
            Status = (BusinessLayer.Enums.Status?)(byte?)element["Status"];
        }
        

        public List<PC> GetPCsByTypeID()
        {
            List<PC> PCList = null;
            try
            {
                DbDataAccess db = new DbDataAccess();
               
                List<SPParam> par = new List<SPParam>();
                par.Add(new SPParam("typeID",(byte)this.TypeOfPC));
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetPCsByTypeID", par);

                if (result!= null && result.Count !=0 )
                {
                    PCList = new List<PC>(result.Count);
                    foreach (var item in result)
                    {
                        PC _pc = new PC(item);
                        PCList.Add(_pc);
                    }
                }
                return PCList;

            }
            catch (Exception ex)
            {
                return PCList;
            }
        }

        

    }       


}
