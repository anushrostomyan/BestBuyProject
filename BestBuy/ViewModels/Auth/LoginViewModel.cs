using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Entity.Auth;
using Microsoft.AspNetCore.Authorization;

namespace BestBuy.ViewModels.Auth
{
    class LoginValidationMessage
    {
        public static string UserNameErrMsg { get; set; }
        public static string PasswordErrMsg { get; set; }
    }
    
    public class LoginViewModel
    {
        
        [Required(ErrorMessageResourceType = typeof(LoginValidationMessage),ErrorMessageResourceName = "UserNameErrMsg")]
        [StringLength(20), MinLength(5)]
        //[RegularExpression(@"[A-Z] [a-z]")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(LoginValidationMessage),ErrorMessageResourceName = "PasswordErrMsg")] 
        [StringLength(20), MinLength (6)]
        //[RegularExpression(@" ogtagorcel [a-z] ev [0-9] tvanshannery")]
        public string Password { get; set; }
    }
}
