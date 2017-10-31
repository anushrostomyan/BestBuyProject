using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Enums
{
    #region UserType
    public enum UserType : byte
    {
        User = 0,
        Admin = 1
    }
    
#endregion
    public enum PCType : byte
    {
        Desktop = 1,
        Laptop = 2,
        ALLInOne = 3
    }
    public enum MobTabEnums : byte
    {
        Mobilephones = 1,
        Tablets = 2
    }
    public enum Availability
    {
        NonStock = 1,
        InStock = 2
    }

    public enum Status : byte
    {
        Deleted = 0,
        Active = 1
    }
    public enum CoffeeType : byte
    {
        Americano = 1,
        Espresso = 2,
    }

    public enum Filter : byte
    {
        Yes = 1,
        No = 2,
    }
    public enum Bowel : byte
    {
        Yes = 1,
        No = 2,
    }
    public enum Sex : byte
    {
        Famale = 0,
        Male = 1        
    }

}
