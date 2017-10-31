using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestBuy.ViewModels.Auth;
using BusinessLayer.Entity.Auth;
using BestBuy.ViewModels;
using System.Security;
using BusinessLayer.Entity;
using BestBuy.ViewModels.User;
using BusinessLayer.Enums;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestBuy.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
         public IActionResult GetAllUser()
        {
            User user = new User();
            List<User> userList = user.GetAllUsers();
            List<GetUserViewModel> ViewModel = new List<GetUserViewModel>();

            foreach (User entity in userList )
            {
                GetUserViewModel vModel = new GetUserViewModel(entity.FirstName,entity.LastName,entity.TellNumber,
                                                               entity.Email,entity.Address,entity.Sex,entity.BirthDate,
                                                               entity.UserName,entity.Password,entity.Status,
                                                               entity.TypeOfUser);

                ViewModel.Add(vModel);
            }

            return View(ViewModel);
        }
               

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(AddUserViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {                
                User user = new User(model.FirstName,model.LastName,
                                     model.UserName,model.Password,
                                     model.Email,model.Sex);

                user.AddUser();


                return RedirectToAction("Index", "Bonus");
            }
            return View(model);
        }
    }
}
