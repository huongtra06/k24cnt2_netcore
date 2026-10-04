using LHTLesson14.Data;
using LHTLesson14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LHTLesson14.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriesController(LHTLesson14Context db) : Controller
{
    public async Task<IActionResult> Index(string? keyword)
    {
        var query = db.Categories.Include(c => c.Products).AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(c => c.Name.Contains(keyword));

        ViewBag.Keyword = keyword;
        return View(await query.OrderBy(c => c.Name).ToListAsync());
    }

    public IActionResult Create()
    {
        return View(new Category { Status = 1, CreatedDate = DateTime.Today });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (await db.Categories.AnyAsync(c => c.Name == category.Name))
            ModelState.AddModelError(nameof(category.Name), "Tên danh mục đã tồn tại.");

        if (ModelState.IsValid)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            TempData["Success"] = "Đã thêm danh mục.";
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var category = await db.Categories.FindAsync(id);
        return category == null ? NotFound() : View(category);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Category category)
    {
        if (id != category.Id) return BadRequest();

        if (await db.Categories.AnyAsync(c => c.Name == category.Name && c.Id != id))
            ModelState.AddModelError(nameof(category.Name), "Tên danh mục đã tồn tại.");

        if (ModelState.IsValid)
        {
            db.Entry(category).State = EntityState.Modified;
            await db.SaveChangesAsync();
            TempData["Success"] = "Đã cập nhật danh mục.";
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var category = await db.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        return category == null ? NotFound() : View(category);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var category = await db.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

        if (category == null) return NotFound();

        if (category.Products.Any())
        {
            TempData["Error"] = "Không thể xóa danh mục đang có sản phẩm.";
            return RedirectToAction(nameof(Index));
        }

        db.Categories.Remove(category);
        await db.SaveChangesAsync();
        TempData["Success"] = "Đã xóa danh mục.";

        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleStatus(int id)
    {
        var category = await db.Categories.FindAsync(id);
        if (category == null) return NotFound();

        category.Status = category.Status == 1 ? (byte)0 : (byte)1;
        await db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
