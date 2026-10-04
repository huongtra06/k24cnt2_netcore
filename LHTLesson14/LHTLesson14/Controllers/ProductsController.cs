using LHTLesson14.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LHTLesson14.Controllers;

public class ProductsController(LHTLesson14Context db) : Controller
{
    public async Task<IActionResult> Index(int? categoryId, string? keyword, decimal? minPrice, decimal? maxPrice)
    {
        var query = db.Products
            .Include(p => p.Category)
            .Where(p => p.Status == 1)
            .AsNoTracking();

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(p => p.Name.Contains(keyword) ||
                                     (p.Description != null && p.Description.Contains(keyword)) ||
                                     (p.Category != null && p.Category.Name.Contains(keyword)));

        if (minPrice.HasValue)
            query = query.Where(p => (p.SalePrice > 0 ? p.SalePrice : p.Price) >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(p => (p.SalePrice > 0 ? p.SalePrice : p.Price) <= maxPrice.Value);

        ViewBag.Categories = await db.Categories.Where(c => c.Status == 1).OrderBy(c => c.Name).ToListAsync();
        ViewBag.CategoryId = categoryId;
        ViewBag.Keyword = keyword;
        ViewBag.MinPrice = minPrice;
        ViewBag.MaxPrice = maxPrice;

        return View(await query.OrderByDescending(p => p.Id).ToListAsync());
    }

    public async Task<IActionResult> Search(string? keyword)
    {
        return RedirectToAction(nameof(Index), new { keyword });
    }

    public async Task<IActionResult> Hots()
    {
        var products = await db.Products
            .Include(p => p.Category)
            .Where(p => p.Status == 1)
            .OrderByDescending(p => p.SalePrice > 0 ? p.Price - p.SalePrice : 0)
            .ThenByDescending(p => p.Id)
            .Take(8)
            .AsNoTracking()
            .ToListAsync();

        return View("Index", products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await db.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id && p.Status == 1);

        return product == null ? NotFound() : View(product);
    }
}
