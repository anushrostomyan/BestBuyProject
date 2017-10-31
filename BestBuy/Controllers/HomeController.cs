using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BestBuy.ViewModels.Accessories;
using BusinessLayer.Entity;

namespace BestBuy.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            int? id = null;
            //int? id = HttpContext.Session.GetInt32("id");
            byte[] text = HttpContext.Session.Get("id");
            if (text != null)
            {
                string str = System.Text.Encoding.UTF8.GetString(text);
                try
                {
                    id = Int32.Parse(str);
                }
                catch (Exception)
                {

                    return null;
                }

            }
            ViewData["FirstName"] = "";
            if (id != null)
            {
                User user = new User();
                user.GetById((int)id);
                if (user.ProcessingErrorID != 0)
                    ViewData["FirstName"] = user.UserName;
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
