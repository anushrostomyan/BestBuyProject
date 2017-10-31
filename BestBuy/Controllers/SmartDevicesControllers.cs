using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestBuy.ViewModels.Smartphones;
using BusinessLayer.Entity;
using BusinessLayer.Enums;

namespace BestBuy.Controllers
{
    public class SmartDevicesControllers : Controller
    {
        public IActionResult Index()
        {
            SmartDevicesViewModel SpVM = new SmartDevicesViewModel();
            return View(SpVM);
        }

        [HttpGet]
        public IActionResult GetMobilephonesType(byte typeID)
        {
            if (Enum.IsDefined(typeof(MobTabEnums), typeID))
            {
                MobTabEnums type = (MobTabEnums)typeID;
                SmartDevices SmD = new SmartDevices(mobTabType: type);
                List<SmartDevices> listOfSmD = SmD.GetAllSmartDevices();
                List<MobTabViewModel> MTViewModel = new List<MobTabViewModel>();

                foreach (SmartDevices entity in listOfSmD)
                {
                    MobTabViewModel MTVModel = new MobTabViewModel(entity.ID, entity.Name, entity.Model,
                        entity.Color, entity.Price, entity.SIZE, entity.SIM, entity.MEMORY, entity.CAMERA,
                        entity.CPU, entity.BATTERY, entity.MobTabType); 

                    MTViewModel.Add(MTVModel);
                }
                string typeName = null;
                switch (type)
                {
                    case MobTabEnums.Mobilephones:
                        typeName = "Mobile Phones list";
                        break;
                    case MobTabEnums.Tablets:
                        typeName = "Tablets list";
                        break;
                }

                ViewData["prodType"] = typeName;
                return View(MTViewModel);
            }
            return View("Home/Error");
        }

        
    }
}
