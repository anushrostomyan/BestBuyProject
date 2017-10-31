using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Entity;
using BestBuy.ViewModels.KitchenAppliance;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestBuy.Controllers
{
    public class KitchenApplianceController : Controller
    {
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult GetAllFoodProcessors()
        {
            FoodProcessor fp = new FoodProcessor();
            List<FoodProcessor> foodprocList = fp.GetAllFoodProcessors();
            List<FoodProcessorViewModel> foodprocViewModelList = new List<FoodProcessorViewModel>();

            foreach (FoodProcessor entity in foodprocList)
            {
                FoodProcessorViewModel fpViewModel = new FoodProcessorViewModel(entity.FoodProcessorModel, entity.FoodProcessorPower, entity.FoodProcessorPrice,
                entity.FoodProcessorNumberOfSpeed, entity.FoodProcessorNumberOfFunction, entity.FoodProcessorAvailability, entity.FoodProcessorColor, entity.FoodProcessorDate);

                foodprocViewModelList.Add(fpViewModel);
            }
            return View(foodprocViewModelList);

        }

        public IActionResult GetAllCoffeeMakers()
        {
            CoffeeMaker coffeemaker = new CoffeeMaker();
            List<CoffeeMaker> coffeemakerList = coffeemaker.GetAllCoffeeMakers();
            List<CoffeeMakerViewModel> coffeemakerViewModelList = new List<CoffeeMakerViewModel>();

            foreach (CoffeeMaker entity in coffeemakerList)
            {
                CoffeeMakerViewModel cmViewModel = new CoffeeMakerViewModel(entity.CoffeeMakerModel, entity.CoffeeMakerPower, entity.CoffeeMakerType, entity.CoffeeMakeFilter, entity.CoffeeMakerPrice,
                entity.CoffeeMakerAvailability, entity.CoffeeMakerColor, entity.CoffeeMakerDate);
                coffeemakerViewModelList.Add(cmViewModel);
            }

            return View(coffeemakerViewModelList);
        }

        public IActionResult GetAllJuicers()
        {
            Juicer juicer = new Juicer();
            List<Juicer> juicerList = juicer.GetAllJuicers();
            List<JuicerViewModel> juicerViewModelList = new List<JuicerViewModel>();

            foreach (Juicer entity in juicerList)
            {
                JuicerViewModel juicerViewModel = new JuicerViewModel(entity.JuicerModel, entity.JuicerPower, entity.JuicerPrice, entity.JuicerNumberOfSpeed, 
                entity.JuicerVolme, entity.JuicerAvailability, entity.JuicerColor, entity.JuicerDate);
                juicerViewModelList.Add(juicerViewModel);
            }
            return View(juicerViewModelList);

        }

        public IActionResult GetAllKettles()
        {
            Kettle kettle = new Kettle();
            List<Kettle> kettleList = kettle.GetAllKettles();
            List<KettleViewModel> kettleViewModelList = new List<KettleViewModel>();

            foreach (Kettle entity in kettleList)
            {
                KettleViewModel kettleViewModel = new KettleViewModel(entity.KettleModel, entity.KettlePower, entity.KettlePrice, entity.KettleVolme, entity.KettleFilter,
                entity.KettleAvailability, entity.KettleColor, entity.KettleDate);
            }
            return View(kettleViewModelList);
        }

        public IActionResult GetAllMicrowaves()
        {
            Microwave microwave = new Microwave();
            List<Microwave> microwaveList = microwave.GetAllMicrowaves();
            List<MicrowavesViewModel> microwaveViewModelList = new List<MicrowavesViewModel>();

            foreach (Microwave entity in microwaveList)
            {
                MicrowavesViewModel microwaveViewModel = new MicrowavesViewModel(entity.MicrowaveModel, entity.MicrowavePower, entity.MicrowaveVolme,
                entity.MicrowavePrice, entity.MicrowaveAvailability, entity.MicrowaveColor, entity.MicrowaveDate, entity.ImageAsBase64);
                microwaveViewModelList.Add(microwaveViewModel);
            }
            return View(microwaveViewModelList);
        }

        public IActionResult GetAllMixers()
        {
            Mixer mixer = new Mixer();
            List<Mixer> mixerList = mixer.GetAllMixers();
            List<MixerViewModel> mixerViewModelList = new List<MixerViewModel>();
            foreach (Mixer entity in mixerList)
            {
                MixerViewModel mixerViewModel = new MixerViewModel(entity.MixerModel, entity.MixerPower, entity.MixerPrice, entity.MixerNumberOfSpeed, entity.MixerBowel,
                    entity.MixerAvailability, entity.MixerColor, entity.MixerDate);
            }
            return View(mixerViewModelList);
        }

    }
}
