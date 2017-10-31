using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.User
{
    public class GetUserViewModel
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string TellNumber { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public Sex? Sex { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public UserType? TypeOfUser { get; set; } = UserType.User;
        public Status? Status { get; set; }

        public GetUserViewModel(string fname = null, string lname = null,
                  string telnumber = null, string email = null, string address = null,
                  Sex? sex = null, DateTime? birthDate = null, string username = null,
                  string password = null,Status? status = null,UserType? user = null)
        {            
            this.FirstName = fname;
            this.LastName = lname;
            this.TellNumber = telnumber;
            this.Email = email;
            this.UserName = username;
            this.Password = password;
            this.Address = address;
            this.Sex = sex;
            this.BirthDate = birthDate;            
            this.TypeOfUser = user;
            this.Status = status;
        }

    }
}
