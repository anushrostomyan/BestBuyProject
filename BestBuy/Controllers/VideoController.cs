using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Enums;
using BestBuy.ViewModels.Audio_Video;
using BusinessLayer.Entity;

namespace BestBuy.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult GetAllVideoDevices()
        {
            VideoDevices m = new VideoDevices();
            List<VideoDevices> videoDevicesList = m.GetAllVideoDevices();
            List<VideoDevicesViewModel> viewModel = new List<VideoDevicesViewModel>();

            foreach (VideoDevices entity in videoDevicesList)
            {
                VideoDevicesViewModel vModel = new VideoDevicesViewModel(entity.Brand, entity.MadeInCountry, entity.ProductionDate,
                            entity.Resolution, entity.Diagonal, entity.Brightness, entity.Support, entity.ModelName,
                            entity.Videorecording, entity.Availability, entity.WarrantyYears, entity.Price, entity.ImageAsBase64);
                vModel.ModelName = entity.ModelName;
                viewModel.Add(vModel);
            }
            return View(viewModel);
        }

    }
}


