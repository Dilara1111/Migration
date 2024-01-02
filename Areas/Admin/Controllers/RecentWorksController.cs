using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DAL;
using PurpleBuzz.Models;

namespace PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecentWorksController : Controller
    {
        private readonly AppDbContext _dbContext;

        public RecentWorksController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<RecentWork> recentWorks = await _dbContext.RecentWorks.ToListAsync();
            return View(recentWorks);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RecentWork recentWork)
        {
            if (!ModelState.IsValid) return View(recentWork);
            bool isExit = await _dbContext.RecentWorks
            .AnyAsync(x => x.Title.ToLower().Trim() == recentWork.Title.ToLower().Trim());
            if (isExit)
            {
                ModelState.AddModelError("Title", "Kateqoriya movcuddur");
                return View(recentWork);
            }
            await _dbContext.RecentWorks.AddAsync(recentWork);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));  
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            RecentWork recentwork = await _dbContext.RecentWorks.FindAsync(id);
            if (recentwork == null)
            {
                return NotFound();
            }
            return View(recentwork);
        }
        [HttpPost]
        public async Task<IActionResult> Update(RecentWork recentWork, int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            RecentWork? dbRecentWork = await _dbContext.RecentWorks.FindAsync(id);

            if (dbRecentWork == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(dbRecentWork);
            }

            bool isExist = await _dbContext.RecentWorks
         .AnyAsync(x => x.Title.ToLower().Trim() == recentWork.Title.ToLower().Trim() && x.Id!=id);

            if (isExist)
            {
                ModelState.AddModelError("Title", "It's title already is exist");
                return View();
            }

            dbRecentWork.Title = recentWork.Title;
            dbRecentWork.Description = recentWork.Description;
            dbRecentWork.FilePath = recentWork.FilePath;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
