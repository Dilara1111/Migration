using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DAL;
using PurpleBuzz.Models;


namespace PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext appDbContext) 
        {
            _dbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _dbContext.Categories.ToListAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            bool isExit = await _dbContext.Categories
            .AnyAsync(x => x.Title.ToString().Trim() == category.Title.ToString().Trim()); // Tostringi ToLower deyishmek lazimdir
            if (isExit)
            {
                ModelState.AddModelError("Title", "Kateqoriya movcuddur");
                return View(category);
            }
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); // "Index" de yaza bilerik amma best praxis budur
        }

        
    }
}
