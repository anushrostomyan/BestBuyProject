using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess;
using BusinessLayer.Enums;

namespace BusinessLayer.Entity
{
    public class Branch
    {
        public int? ID { get; private set; }
        public double? X_Coordinate { get; private set; }
        public double? Y_Coordinate { get; private set; }
        public string Address { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string WorkingHours { get; private set; }
        public string District { get; private set; }
        public Status? Status { get; private set; }

        //public int? ID { get; set; }
        //public double? X_Coordinate { get; set; }
        //public double? Y_Coordinate { get; set; }
        //public string Address { get; set; }
        //public string Name { get; set; }
        //public string PhoneNumber { get; set; }
        //public string WorkingHours { get; set; }
        //public string District { get; set; }
        //public Status? Status { get; set; }

        public Branch()
        {

        }

        public Branch(int? Id = null,
                      string address = null,
                      string name = null,
                      string phoneNumber = null,
                      string workingHours = null,
                      string district = null,
                      Status? status = null,
                      float? xCoordinate = null,
                      float? yCoordinate = null)
        {
            this.ID = Id;
            this.Address = address;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.WorkingHours = workingHours;
            this.District = district;
            this.Status = status;
            this.X_Coordinate = xCoordinate;
            this.Y_Coordinate = yCoordinate;
        }

        private Branch(Dictionary<string, object> element)
        {
            this.ID = (int?)element["ID"];
            this.Address = (string)element["Adress"];
            this.Name = (string)element["Name"];
            this.PhoneNumber = (string)element["PhoneNumber"];
            this.WorkingHours = (string)element["WorkingHours"];
            this.District = (string)element["District"];
            this.Status = (Status)(byte?)element["Status"];
            this.X_Coordinate = (double?)element["X_Coordinate"];
            this.Y_Coordinate = (double?)element["Y_Coordinate"];
        }

        public List<Branch> GetAllBranches()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<Branch> BranchesList = null;
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllBranches", new List<SPParam>());

                if (result != null && result.Count != 0)
                {
                    BranchesList = new List<Branch>(result.Count);
                    foreach (Dictionary<string,object> branch in result)
                    {
                        Branch _branches = new Branch(branch);
                        BranchesList.Add(_branches);
                    }
                }
                return BranchesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
