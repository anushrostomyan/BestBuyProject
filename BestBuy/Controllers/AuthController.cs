using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestBuy.ViewModels.Auth;
using BusinessLayer.Entity;
using BestBuy.CommonModels.ExtensionMethods;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestBuy.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //if(model== null)
            //{
            //    int userId = HttpContext.Session.Get<int>("id");
            //}

            if (model != null && ModelState.IsValid)
            {
                //HttpContext.Session.Set("id", 123);
                //return RedirectToAction("Index","Home");


                User user = new User(username: model.UserName, password: model.Password);
                User logedInUser = user.Login();
                if (logedInUser != null)
                {
                    if (logedInUser.ProcessingErrorID == null)
                    {
                        HttpContext.Session.Set<Int32?>("id", logedInUser.ID);
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("Error", "Home");
                }
                                
                return View();
            }
            return View(model);
        }
    }
}
