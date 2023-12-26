using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DAL;
using PurpleBuzz.Models;
using PurpleBuzz.ViewModels.About;
using System;
using System.Drawing.Text;

namespace PurpleBuzz.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public AboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var cards = await _appDbContext.Cards.ToListAsync();        //    List<Cards> cards = new List<Cards>
                                                                        //    {
                                                                        //        new Cards {Id=1,FilePath = "display-4 bx bxs-bulb text-light",Title="Our Vision", Description = "Incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse commodo viverra.\r\n"},
                                                                        //        new Cards {Id=2,FilePath = "display-4 bx bx-revision text-light",Title="Our Mission", Description = "Incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse commodo viverra.\r\n"},
                                                                        //        new Cards {Id=3,FilePath = "display-4 bx bxs-select-multiple text-light",Title="Our Goal", Description = "Incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse commodo viverra.\r\n"}
                                                                        //    };
                                                                        //    AboutIndexViewModel model = new AboutIndexViewModel { Cards = cards };
            AboutIndexViewModel model = new AboutIndexViewModel
            {
                Cards = cards
            }; 
            return View(cards);
        }
    }
}
