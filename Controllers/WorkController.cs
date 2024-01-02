using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DAL;
using PurpleBuzz.ViewModels.Work;

namespace PurpleBuzz.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public WorkController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _appDbContext.Categories.
                Include(x => x.CategoryComponents).         // Run Time uzanmasin deye Include edirik, eger lazimdirsa getirir
                ToListAsync();
            WorkIndexViewModel model = new WorkIndexViewModel
            {
                Categories = categories

            };

            return View(model);
        }
    }
}
