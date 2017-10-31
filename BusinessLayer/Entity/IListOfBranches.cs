using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public interface IListOfBranches
    {
        IEnumerable<Branch> Branches { get; }
    }
}
