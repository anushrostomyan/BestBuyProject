using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.User
{
    class AddUserValidationMessages
    {
        public static string FirstNameErrMsg { get; set; }
        public static string LastNameErrMsg { get; set; }
        public static string UserNameErrMsg { get; set; }
        public static string PasswordErrMsg { get; set; }
        public static string EmailErrMsg { get; set; }

    }

    public class AddUserViewModel
    {
        [Required(ErrorMessageResourceType =typeof(AddUserValidationMessages),ErrorMessageResourceName = "FirstNameErrMsg")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(AddUserValidationMessages),ErrorMessageResourceName = "LastNameErrMsg")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(AddUserValidationMessages),ErrorMessageResourceName = "UserNameErrMsg")]
        [StringLength(20), MinLength(5)]
        //[RegularExpression(@"^[A-Z] [a-z]*$")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(AddUserValidationMessages),ErrorMessageResourceName = "PasswordErrMsg")]
        [StringLength(20), MinLength(6)]
        //[RegularExpression(@"ogtagorcel [a-z] ev [0-9] tvanshannery")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(AddUserValidationMessages), ErrorMessageResourceName = "EmailErrMsg")]
        public string Email { get; set; }

        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public string TellNumber { get; set; }
        public Sex Sex { get; set; }
        public UserType TypeOfUser { get; set; }  
        public DateTime? BirthDate { get; set; }
    }
}
