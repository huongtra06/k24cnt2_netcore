using LHTraLesson12.AppDBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LHTraLesson12.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _context.Categories.Where(c => c.Status == 1).OrderBy(c => c.Id).ToListAsync();
            ViewBag.Products = await _context.Products.Include(p => p.Category).Where(p => p.Status == 1).OrderByDescending(p => p.Id).Take(8).AsNoTracking().ToListAsync();
            ViewBag.ProductCount = await _context.Products.CountAsync();
            ViewBag.CategoryCount = await _context.Categories.CountAsync();
            return View();
        }

        public IActionResult Privacy() => View();
        public IActionResult Error() => View();
    }
}
