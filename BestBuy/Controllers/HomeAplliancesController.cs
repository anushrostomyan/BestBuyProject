using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Entity;
using BestBuy.ViewModels.HomeAppliances;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestBuy.Controllers
{
    public class HomeAppliancesController : Controller
    {
        public IActionResult GetAllFreezers()
        {
            Freezer m = new Freezer();
            List<Freezer> freezerList = m.GetAllFreezers();
            List<FreezerViewModel> viewModelfreezer = new List<FreezerViewModel>();

            foreach (Freezer entity in freezerList)
            {
                FreezerViewModel MModel = new FreezerViewModel(entity.Id, entity.Company, entity.Name, entity.Price,
                                                           entity.Colour, entity.Dimensions, entity.NumberOfDoors, entity.TotalCapacity, entity.ImageAsBase64);
                viewModelfreezer.Add(MModel);
            }

            return View(viewModelfreezer);
        }



        public IActionResult GetAllVacuumCleaners()
        {
            VacuumCleaner m = new VacuumCleaner();
            List<VacuumCleaner> vacuumCleanerList = m.GetAllVacuumCleaners();
            List<VacuumCleanerViewModel> viewModelVacuumCleaner = new List<VacuumCleanerViewModel>();

            foreach (VacuumCleaner entity in vacuumCleanerList)
            {
                VacuumCleanerViewModel MModel = new VacuumCleanerViewModel(entity.Id, entity.Company, entity.Name, entity.Price,
                                                           entity.MaximumPower, entity.SuctionPower, entity.DustBagCapacity, entity.ImageAsBase64);
                viewModelVacuumCleaner.Add(MModel);
            }

            return View(viewModelVacuumCleaner);
        }


        public IActionResult GetAllAirConditioners()
        {
            AirConditioner m = new AirConditioner();
            List<AirConditioner> airConditionerList = m.GetAllAirConditioners();
            List<AirConditionerViewModel> viewModelAirConditioner = new List<AirConditionerViewModel>();

            foreach (AirConditioner entity in airConditionerList)
            {
                AirConditionerViewModel MModel = new AirConditionerViewModel(entity.Id, entity.Company, entity.Name, entity.Price,
                                                           entity.WorkingSpace, entity.AirFlow,  entity.WorkingTemperature, entity.ImageAsBase64);
                viewModelAirConditioner.Add(MModel);
            }

            return View(viewModelAirConditioner);
        }

    }
}
