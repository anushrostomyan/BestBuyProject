using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Entity;
using BestBuy.ViewModels.Branches;


namespace BestBuy.Controllers
{
    public class BranchController : Controller
    {



        public IActionResult GetBranches()
        {

            Branch b = new Branch();
            List<Branch> branchesList = b.GetAllBranches();

            string markers = "[";

            if (branchesList != null)
            {
                List<BranchViewModel> branchList = new List<BranchViewModel>(branchesList.Count);
                foreach (Branch entity in branchesList)
                {

                    BranchViewModel branchView = new BranchViewModel(entity.X_Coordinate,
                                                                     entity.Y_Coordinate,
                                                                     entity.Address,
                                                                     entity.Name,
                                                                     entity.PhoneNumber,
                                                                     entity.WorkingHours,
                                                                     entity.District);

                    markers += "{";
                    markers += string.Format("'title': '{0}',", entity.Name);
                    markers += string.Format("'lat': '{0}',", entity.X_Coordinate);
                    markers += string.Format("'lng': '{0}',", entity.Y_Coordinate);
                    markers += "},";


                    branchList.Add(branchView);
                }
                markers += "];";
                ViewBag.Markers = markers;

                return View(branchList);
            }



            //error page
            return View();
        }
        

        //List<Branch> branchesList;

        //public BranchController()
        //{
        //    Branch Arshakunyats = new Branch { Name = "Arshakunyats", District = "Yerevan", PhoneNumber = "010-060-567", Address = "Arshakunyats 43", WorkingHours = "9:00 - 18:00", X_Coordinate = 40.157585, Y_Coordinate = 44.502219 };
        //    Branch Mashtots = new Branch { Name = "Mashtots", District = "Yerevan", PhoneNumber = "010-590-610", Address = "Mashtots 16/2", WorkingHours = "10:00 - 19:00", X_Coordinate = 40.184288, Y_Coordinate = 44.511787 };
        //    Branch Komitas = new Branch { Name = "Komitas", District = "Yerevan", PhoneNumber = "060-567-789", Address = "Komitasi 17", WorkingHours = "9:00 - 18:30", X_Coordinate = 40.206324, Y_Coordinate = 44.507478 };
        //    Branch Dilijan = new Branch { Name = "Dilijan", District = "Tavush", PhoneNumber = "011-111-234", Address = "Antarapajneri 10/1", WorkingHours = "10:00 - 18:00", X_Coordinate = 40.740542, Y_Coordinate = 44.867627 };
        //    Branch Alaverdi = new Branch { Name = "Alaverdi", District = "Lori", PhoneNumber = "060-187-691", Address = "Shinararneri 18", WorkingHours = "10:00 - 18:00", X_Coordinate = 41.090510, Y_Coordinate = 44.663243 };
        //    Branch Kapan = new Branch { Name = "Kapan", District = "Syunik", PhoneNumber = "011-167-942", Address = "Kutuzov 13/3", WorkingHours = "10:00 - 18:00", X_Coordinate = 39.207022, Y_Coordinate = 46.399617 };

        //    branchesList = new List<Branch> { Arshakunyats, Mashtots, Komitas, Dilijan, Alaverdi, Kapan };
        //}

        //public IActionResult FakeList()
        //{
        //    return View(branchesList);
        //}

    }
}
