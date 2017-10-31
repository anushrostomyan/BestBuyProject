using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BestBuy.ViewModels.Test;
//using SixLabors.ImageSharp;
using DataAccessLayer.DataAccess;
using System.IO;
using Microsoft.Extensions.FileProviders;
using BusinessLayer.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestBuy.Controllers
{
    public class ImageUploadController : Controller
    {
        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }


        [HttpPost]
        public IActionResult FileUpload(ImageUploadViewModel model)
        {
            ImageProcessing proc = new ImageProcessing();
            SmartDevices SDve = new SmartDevices();
            int SDveId = 24;
            byte[] imagebyte = proc.ConvertToBytes(model.Image);
            bool? result = SDve.UpdateSmartDevicesImage(imagebyte, SDveId);

            switch (result)
            {
                case true:

                    break;
             default:

                    break;
            }
            return View();
        }
    }
}

