using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class Freezer
    {
        public int? Id { get; private set; }
        public string Company { get; private set; }
        public string Name { get; private set; }
        public double? Price { get; private set; }
        public byte? NumberOfDoors { get; private set; }
        public double? TotalCapacity { get; private set; }
        public string Dimensions { get; private set; }
        public string Colour { get; private set; }
        public string ImageAsBase64 { get; private set; }

        public Freezer()
        {

        }

        public Freezer(int Id, string Company, string Name, double Price, string Colour,
                          string Dimensions, byte NumberOfDoors, float TotalCapacity, string ImageAsBase64)
        {
            this.Id = Id;
            this.Price = Price;
            this.Company = Company;
            this.Name = Name;
            this.Colour = Colour;
            this.Dimensions = Dimensions;
            this.NumberOfDoors = NumberOfDoors;
            this.TotalCapacity = TotalCapacity;
            this.ImageAsBase64 = ImageAsBase64;
        }

        private Freezer(Dictionary<string, object> element)
        {
            this.Id = (int?)element["Id"];
            this.Company = (string)element["Company"];
            this.Name = (string)element["Name"];
            this.Price = (double?)element["Price"];
            this.NumberOfDoors = (byte?)element["NumberOfDoors"];
            this.TotalCapacity = (double?)element["TotalCapacity"];
            this.Dimensions = (string)element["Dimensions"];
            this.Colour = (string)element["Colour"];
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;

        }

        public List<Freezer> GetAllFreezers()
        {
            try

            {
                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllFreezers", new List<SPParam>());
                List<Freezer> FreezerList = new List<Freezer>();
                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        Freezer _freezer = new Freezer(item);
                        FreezerList.Add(_freezer);
                    }
                }
                return FreezerList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool? UpdateFreezerImage(byte[] imagebyte, int freezerId)

        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("freezerId", freezerId));

                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateFreezerImage", param);
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
    