using System;
using System.Collections.Generic;
using DataAccessLayer.DataAccess;

namespace BusinessLayer.Entity
{
    public class GamingConsole
    {
        public int?    Id { get; private set; }
        public string  Name { get; private set; }
        public string  Developer { get; private set; }       
        public string  Manufacturer { get; private set; }
        public string  ProductFamily { get; private set; }
        public string  Generation { get; private set; }
        public string  Type { get; private set; }
        public bool    RetailAvailability { get; private set; }
        public decimal Price { get; private set; }
        public string  Graphics { get; private set; }
        public string  Display { get; private set; }
        public string  BestSellingGame { get; private set; }
        public string  ImageAsBase64 { get; private set; }

        enum Consoles : byte
        {
            XboxOneS,
            NintendoSwitch,
            Nintendo3DS,
            WiiU,
            PlayStation4
        }

        public GamingConsole()
        {
        }

        public GamingConsole(int? Id, string name, string developer, string manufacturer, string productFamily,
                              string generation, bool retailAvailability, decimal price, string graphics, string display,
                              string bestSellingGame, string imageAsBase64)
        {
            Name = name;
            Developer = developer;
            Manufacturer = manufacturer;
            ProductFamily = productFamily;
            Generation = generation;
            RetailAvailability = retailAvailability;
            Price = price;
            Graphics = graphics;
            BestSellingGame = bestSellingGame;
            Display = display;
            ImageAsBase64 = imageAsBase64;
            
        }

        private GamingConsole(Dictionary<string, object> element)
        {
            Id = (int?)element["Id"];
            Name = (string)element["Name"];
            Developer = (string)element["Developer"];
            Manufacturer = (string)element["Manufacturer"];
            ProductFamily = (string)element["Product Family"];
            Generation = (string)element["Generation"];
            RetailAvailability = (bool)element["Retail Availability"];
            Price = (decimal)element["Price"];
            Graphics = (string)element["Graphics"];
            Display = (string)element["Display"];
            BestSellingGame = (string)element["Best Selling Game"];
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;
        }

        public List<GamingConsole> GetAllConsoles()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<GamingConsole> consolesList = new List<GamingConsole>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllConsoles", new List<SPParam>());
                if (result != null && result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        GamingConsole _console = new GamingConsole(item);
                        consolesList.Add(_console);
                    }
                }
                return consolesList;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool? UpdateGamingConsoleImage(byte[] imagebyte, int gamingConsoleId)
        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("gamingConsoleId", gamingConsoleId));
                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateGamingConsoleImage", param);
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
