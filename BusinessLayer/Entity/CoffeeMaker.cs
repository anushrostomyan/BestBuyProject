using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;
using DataAccessLayer.DataAccess;

public class CoffeeMaker
{

    public int? ID { get; private set; }
    public string CoffeeMakerModel { get; private set; }
    public double? CoffeeMakerPower { get; private set; }
    public CoffeeType? CoffeeMakerType { get; private set; }
    public Filter? CoffeeMakerFilter { get; private set; }
    public double? CoffeeMakerPrice { get; private set; }
    public int? CoffeeMakerAvailability { get; private set; }
    public string CoffeeMakerColor { get; private set; }
    public DateTime? CoffeeMakerDate { get; private set; }
    public Status? Status { get; private set; }
    public string ImageAsBase64 { get; private set; }
    public Filter? CoffeeMakeFilter { get; set; }

    public CoffeeMaker()
    {

    }


    public CoffeeMaker(int? ID = null, string CoffeeMakerModel = null, double? CoffeeMakerPower = null, CoffeeType? CoffeeMakerType = null, Filter? CoffeeMakeFilter = null,
            double? CoffeeMakerPrice = null, int? CoffeeMakerAvailability = null, string CoffeeMakerColor = null, DateTime? CoffeeMakerDate = null, Status? Status = null, string ImageAsBase64 = null)
    {
        this.ID = ID;
        this.CoffeeMakerModel = CoffeeMakerModel;
        this.CoffeeMakerPower = CoffeeMakerPower;
        this.CoffeeMakerType = CoffeeMakerType;
        this.CoffeeMakerFilter = CoffeeMakeFilter;
        this.CoffeeMakerPrice = CoffeeMakerPrice;
        this.CoffeeMakerAvailability = CoffeeMakerAvailability;
        this.CoffeeMakerColor = CoffeeMakerColor;
        this.CoffeeMakerDate = CoffeeMakerDate;
        this.Status = Status;
        this.ImageAsBase64 = ImageAsBase64;
    }

   

    private CoffeeMaker(Dictionary<string, object> elementDictionary)
    {
        this.ID = (int?)elementDictionary["ID"];
        this.CoffeeMakerModel = (string)elementDictionary["CoffeeMakerModel"];
        this.CoffeeMakerPower = (double?)elementDictionary["CoffeeMakerPower"];
        this.CoffeeMakerType = (CoffeeType?)((byte)elementDictionary["CoffeeMakerType"]);
        this.CoffeeMakerFilter = (Filter?)((byte)elementDictionary["CoffeeMakeFilter"]);
        this.CoffeeMakerPrice = (double?)elementDictionary["CoffeeMakerPrice"];
        this.CoffeeMakerAvailability = (int?)elementDictionary["CoffeeMakerAvailability"];
        this.CoffeeMakerColor = (string)elementDictionary["CoffeMakerColor"];
        this.CoffeeMakerDate = (DateTime?)elementDictionary["CoffeeMakerDate"];
        this.Status = (Status?)((byte)elementDictionary["Status"]);
        this.ImageAsBase64 = elementDictionary["Image"] != null ? Convert.ToBase64String((byte[])elementDictionary["Image"]) : null;
        // this.Status = (Status?)Convert.ToByte(elementDictionary["Status"]);
    }

    public List<CoffeeMaker> GetAllCoffeeMakers()
    {
        try
        {
            DbDataAccess db = new DbDataAccess();
            List<CoffeeMaker> coffeemakerList = new List<CoffeeMaker>();
            List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllCoffeeMakers", new List<SPParam>());

            if (result != null && result.Count != 0)
            {
                foreach (var item in result)
                {
                    CoffeeMaker _coffeemaker = new CoffeeMaker(item);
                    coffeemakerList.Add(_coffeemaker);
                }

            }
            return coffeemakerList;
        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public bool? UpdateCoffeeMakerImage(byte[] imagebyte, int coffeeMakerID)

    {
        try
        {

            List<SPParam> param = new List<SPParam>();
            param.Add(new SPParam("ImgBytes", imagebyte));
            param.Add(new SPParam("coffeeMakerID", coffeeMakerID));

            DbDataAccess db = new DbDataAccess();
            List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateCoffeeMakerImage", param);
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


