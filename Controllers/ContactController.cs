using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DAL;
using PurpleBuzz.ViewModels.About;

namespace PurpleBuzz.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ContactController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var ccontact = await _appDbContext.Contact.ToListAsync();

            AboutIndexViewModel model = new AboutIndexViewModel
            {
                Contact = ccontact
            };
            return View(ccontact);
        }
    }
}
