using LHTLesson14.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LHTLesson14.Controllers;

public class HomeController(LHTLesson14Context db) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Categories = await db.Categories
            .Where(c => c.Status == 1)
            .OrderBy(c => c.Name)
            .ToListAsync();

        ViewBag.FeaturedProducts = await db.Products
            .Include(p => p.Category)
            .Where(p => p.Status == 1)
            .OrderByDescending(p => p.Id)
            .Take(8)
            .ToListAsync();

        ViewBag.ActiveBanners = await db.Banners
            .Where(b => b.Status == 1)
            .OrderBy(b => b.Priority)
            .ToListAsync();

        return View();
    }

    public IActionResult Privacy() => View();
    public IActionResult Error() => View("Error");
}
