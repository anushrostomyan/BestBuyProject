using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Entity;
using BestBuy.ViewModels.Accessories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestBuy.Controllers
{
    public class CompAccessoriesController : Controller
    {
      
        [HttpGet]
        public IActionResult GetAllMouses()
        {
            Mouse m = new Mouse();
            List<Mouse> mouseList = m.GetAllMouses();
            List<MouseViewModel> viewModelmouse = new List<MouseViewModel>();

            foreach (Mouse entity in mouseList)
            {
                MouseViewModel MModel = new MouseViewModel(entity.Name, entity.Brand,
                                                           entity.Price, entity.Color,
                                                           entity.Availability, entity.ConnectivityTechnology,
                                                           entity.ProductionDate, entity.ImageAsBase64);
                viewModelmouse.Add(MModel);
            }

            return View(viewModelmouse);
        }



        [HttpGet]
        public IActionResult GetAllUSB_Flash()
        {
            USB_Flash usb = new USB_Flash();
            List<USB_Flash> USB_FlashList = usb.GetAllUSB_Flash();
            List<USBFlashViewModel> viewmodelusb_flash = new List<USBFlashViewModel>();

            foreach (USB_Flash entity in USB_FlashList)
            {
                USBFlashViewModel UModel = new USBFlashViewModel(entity.Name, entity.Brand, entity.Price,
                                                                 entity.MemoryCapacity, entity.Color, entity.Material,
                                                                 entity.USBStandard, entity.DataTransferRate, 
                                                                 entity.Availability, entity.ProductionDate, entity.ImageAsBase64);

                viewmodelusb_flash.Add(UModel);
            }

            return View(viewmodelusb_flash);
        }


        [HttpGet]
        public IActionResult GetAllWebCAmeras()
        {
            WebCameras webCameras = new WebCameras();
            List<WebCameras> webcameraslist = webCameras.GetAllWebCameras();
            List<WebCamerasViewModel> viewmodelwebcamera = new List<WebCamerasViewModel>();

            foreach (WebCameras entity in webcameraslist)
            {
                WebCamerasViewModel webCamera = new WebCamerasViewModel(entity.Name, entity.Brand, entity.Price, entity.OS,
                                                                        entity.CableLength, entity.Mpix,
                                                                        entity.Availability, entity.PruductionDate, entity.ImageAsBase64);
                viewmodelwebcamera.Add(webCamera);
            }

            return View(viewmodelwebcamera);
        }

        [HttpGet]
        public IActionResult GetAllKeyboards()
        {
            Keyboards keyboards = new Keyboards();
            List<Keyboards> ListOfKeyboards = keyboards.GetAllKeyboards();
            List<KeyboardsViewModel> ViewModelKeyboards = new List<KeyboardsViewModel>();

            foreach (Keyboards entity in ListOfKeyboards)
            {
                KeyboardsViewModel keyboard = new KeyboardsViewModel(entity.Name, entity.Brand, 
                                                                     entity.Color,
                                                                     entity.NumberOfKeys,
                                                                     entity.OS, entity.Price, 
                                                                     entity.ConnectionTechnology, 
                                                                     entity.Availability,
                                                                     entity.ProductionDate,
                                                                     entity.ImageAsBase64);
                ViewModelKeyboards.Add(keyboard);
            }

            return View(ViewModelKeyboards);
        }

        [HttpGet]
        public IActionResult GetAllLaptopTabletCase()
        {
            LaptopTabletCases LTCase = new LaptopTabletCases();
            List<LaptopTabletCases> ListOfLaptopTabletCase = LTCase.GetAllLaptopTabletCase();
            List<LaptopTabletCasesViewModel> ViewModelLaptopTabletcases = new List<LaptopTabletCasesViewModel>();

            foreach (LaptopTabletCases entity in ListOfLaptopTabletCase)
            {
                LaptopTabletCasesViewModel cases = new LaptopTabletCasesViewModel(entity.Name,
                                                                                      entity.Brand,
                                                                                      entity.Color,
                                                                                      entity.Price,
                                                                                      entity.Size,
                                                                                      entity.Weight,
                                                                                      entity.Material,
                                                                                      entity.Availability,
                                                                                      entity.ProductionDate,
                                                                                      entity.ImageAsBase64);
                ViewModelLaptopTabletcases.Add(cases);
            }

            return View(ViewModelLaptopTabletcases);
        }
    }
}
