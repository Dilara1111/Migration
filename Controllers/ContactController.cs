using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DAL;
using PurpleBuzz.ViewModels.Contact;

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
            ContactIndexVM model = new ContactIndexVM
            {
                Contact = await _appDbContext.Contact.FirstOrDefaultAsync(),
                ContactMedia = await _appDbContext.ContactMedias.ToListAsync()
            };
      
            return View(model);
        }
    }
}
