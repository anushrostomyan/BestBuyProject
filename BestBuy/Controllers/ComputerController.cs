using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestBuy.ViewModels.Computers;
using BusinessLayer.Entity;
using BusinessLayer.Enums;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestBuy.Controllers
{
    public class ComputerController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ComputerViewModel model = new ComputerViewModel();
            return View(model);
        }  
         
        [HttpGet]
        public IActionResult GetPCbyType(byte typeID)
        {
            if (Enum.IsDefined(typeof(PCType),typeID))
            {
                PCType type = (PCType)typeID;
                PC pc = new PC(TypeOfPC:type);
                List<PC> listOfPC = pc.GetPCsByTypeID();
                List<GetPCbyTypeViewModel> viewModel = new List<GetPCbyTypeViewModel>();

                foreach (PC entity in listOfPC)
                {
                    GetPCbyTypeViewModel vModel = new GetPCbyTypeViewModel(entity.ID,entity.ProductName,
                                                                            entity.Price,entity.ScreenSize,
                                                                            entity.ScreenResolution,entity.TouchScreen,
                                                                            entity.Color,entity.CPU,entity.RAM,entity.HDD,
                                                                            entity.SSD,entity.OS,entity.GraphicsCard,entity.WebCam,
                                                                            entity.Weight,entity.Availability,entity.TypeOfPC);
                    viewModel.Add(vModel);
                }
                string typeName = null;
                switch (type)
                {
                    case PCType.Desktop:
                        typeName = "Desktop computers list";
                        break;
                    case PCType.Laptop:
                        typeName = "Laptop computer list";
                        break;
                    case PCType.ALLInOne:
                        typeName = "All in one computer list";
                        break;
                }

                ViewData["prodType"] = typeName;
                return View(viewModel);
            }
            return View("Home/error");
        }

    }
}
