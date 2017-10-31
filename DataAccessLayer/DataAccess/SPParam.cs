using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class SPParam
    {
        public string Name { set; get; }
        public object Value { set; get; }

        public SPParam(string _Name, object _Value)
        {
            Name = _Name;
            Value = _Value;
        }
    }
}
