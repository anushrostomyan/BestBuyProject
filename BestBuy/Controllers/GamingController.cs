using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Entity;
using BestBuy.ViewModels.Gaming;

namespace BestBuy.Controllers
{
    public class GamingController : Controller
    {
        [HttpGet]
        public IActionResult GetAllConsoles()
        {
            GamingConsole console = new GamingConsole();
            List<GamingConsole> consolesList = console.GetAllConsoles();
            List<GamingConsoleViewModel> consolesViewModelList = new List<GamingConsoleViewModel>();

            foreach (GamingConsole entity in consolesList)
            {
                GamingConsoleViewModel gamingConsoleViewModel = new GamingConsoleViewModel(entity.Name, entity.Developer, entity.Manufacturer,
                                                                                           entity.ProductFamily, entity.Generation, entity.RetailAvailability, 
                                                                                           entity.Price, entity.Graphics, entity.Display, entity.BestSellingGame, entity.ImageAsBase64);

                consolesViewModelList.Add(gamingConsoleViewModel);
            }
            return View(consolesViewModelList); 
        }

        [HttpGet]
        public IActionResult GetAllVideoGames()
        {
            VideoGame game = new VideoGame();
            List<VideoGame> gamesList = game.GetAllVideoGames();
            List<VideoGameViewModel> gamesViewModelList = new List<VideoGameViewModel>();

            foreach (VideoGame entity in gamesList)
            {
                VideoGameViewModel videoGameViewModel = new VideoGameViewModel(entity.Name, entity.Developer, entity.Genre, entity.Platform, entity.ColorCategory,
                                                                               entity.Model, entity.Multiplayer, entity.ImageAsBase64);

                gamesViewModelList.Add(videoGameViewModel);
            }
            return View(gamesViewModelList);
        }
    }
}
