using LHTLesson14.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LHTLesson14.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController(LHTLesson14Context db) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.ProductCount = await db.Products.CountAsync();
        ViewBag.ActiveProductCount = await db.Products.CountAsync(p => p.Status == 1);
        ViewBag.CategoryCount = await db.Categories.CountAsync();
        ViewBag.BannerCount = await db.Banners.CountAsync();
        ViewBag.BlogCount = await db.Blogs.CountAsync();
        ViewBag.AveragePrice = await db.Products.Select(p => (decimal?)p.Price).AverageAsync() ?? 0;

        ViewBag.CategoryStats = await db.Categories
            .Select(c => new { c.Name, Count = c.Products.Count })
            .OrderByDescending(x => x.Count)
            .ToListAsync();

        ViewBag.LatestProducts = await db.Products
            .Include(p => p.Category)
            .OrderByDescending(p => p.Id)
            .Take(6)
            .AsNoTracking()
            .ToListAsync();

        return View();
    }
}
