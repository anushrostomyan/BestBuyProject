using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class LaptopTabletCases
    {
        public int? ID { get; private set; }
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public string Color { get; private set; }
        public double? Price { get; private set; }
        public double? Size { get; private set; }
        public double? Weight { get; private set; }
        public string Material { get; private set; }
        public int? Availability { get; private set; }
        public DateTime? ProductionDate { get; set; }
        public Status? Status { get; private set; }
        public string Type { get; private set; }
        public string ImageAsBase64 { get; set; }


        public LaptopTabletCases()
        {

        }


        public LaptopTabletCases(int? ID = null,
                                 string Name = null,
                                 string Brand = null,
                                 string Color = null,
                                 double? Price = null,
                                 double? Size = null,
                                 double? Weight = null,
                                 string Material = null,
                                 int? Availablity = null,
                                 DateTime? ProductionDate = null,
                                 Status? Status = null,
                                 string Type = null,
                                 string ImageAsBase64 = null)
        {
            this.ID = ID;
            this.Name = Name;
            this.Brand = Brand;
            this.Color = Color;
            this.Price = Price;
            this.Size = Size;
            this.Weight = Weight;
            this.Material = Material;
            this.Availability = Availablity;
            this.Status = Status;
            this.Type = Type;
            this.ImageAsBase64 = ImageAsBase64;
        }


        private LaptopTabletCases(Dictionary<string, object> element)
        {
            ID = (int?)element["ID"];
            Name = (string)element["Name"];
            Brand = (string)element["Brand"];
            Color = (string)element["Color"];
            Price = (double?)element["Price"];
            Size = (double?)element["Size"];
            Weight = (double?)element["Weight"];
            Material = (string)element["Material"];
            Availability = (int?)element["Availability"];
            ProductionDate = (DateTime?)element["ProductionDate"];
            Status = (BusinessLayer.Enums.Status)((byte)element["Status"]);
            Type = (string)element["Type"];
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;
        }

        public List<LaptopTabletCases> GetAllLaptopTabletCase()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<LaptopTabletCases> LaptopTabletCasesList = new List<LaptopTabletCases>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllLaptopTabletCases", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        LaptopTabletCases _LTCase = new LaptopTabletCases(item);
                        LaptopTabletCasesList.Add(_LTCase);
                    }
                }
                return LaptopTabletCasesList;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool? UpdateLaptopTabletCasesImage(byte[] imagebyte, int laptoptabletcaseId)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("laptoptabletcasesid", laptoptabletcaseId));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateLaptopTabletCases", param);
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
