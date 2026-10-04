using LHTLesson14.Data;
using LHTLesson14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LHTLesson14.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController(LHTLesson14Context db) : Controller
{
    public async Task<IActionResult> Index(string? keyword, int? categoryId)
    {
        var query = db.Products.Include(p => p.Category).AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(p => p.Name.Contains(keyword) ||
                                     (p.Description != null && p.Description.Contains(keyword)));

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        ViewBag.Keyword = keyword;
        ViewBag.CategoryId = categoryId;
        ViewBag.Categories = await db.Categories.OrderBy(c => c.Name).ToListAsync();

        return View(await query.OrderByDescending(p => p.Id).ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        await LoadCategories();
        return View(new Product { Status = 1, CreatedDate = DateTime.Today });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (await db.Products.AnyAsync(p => p.Name == product.Name))
            ModelState.AddModelError(nameof(product.Name), "Tên sản phẩm đã tồn tại.");

        if (ModelState.IsValid)
        {
            if (product.SalePrice < 0 || product.SalePrice > product.Price)
                ModelState.AddModelError(nameof(product.SalePrice), "Giá khuyến mãi phải nhỏ hơn hoặc bằng giá niêm yết.");
            else
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                TempData["Success"] = "Đã thêm sản phẩm thành công.";
                return RedirectToAction(nameof(Index));
            }
        }

        await LoadCategories(product.CategoryId);
        return View(product);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await db.Products.FindAsync(id);
        if (product == null) return NotFound();

        await LoadCategories(product.CategoryId);
        return View(product);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.Id) return BadRequest();

        if (await db.Products.AnyAsync(p => p.Name == product.Name && p.Id != id))
            ModelState.AddModelError(nameof(product.Name), "Tên sản phẩm đã tồn tại.");

        if (product.SalePrice < 0 || product.SalePrice > product.Price)
            ModelState.AddModelError(nameof(product.SalePrice), "Giá khuyến mãi phải nhỏ hơn hoặc bằng giá niêm yết.");

        if (ModelState.IsValid)
        {
            db.Entry(product).State = EntityState.Modified;
            await db.SaveChangesAsync();
            TempData["Success"] = "Đã cập nhật sản phẩm.";
            return RedirectToAction(nameof(Index));
        }

        await LoadCategories(product.CategoryId);
        return View(product);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        return product == null ? NotFound() : View(product);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await db.Products.FindAsync(id);
        if (product != null)
        {
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            TempData["Success"] = "Đã xóa sản phẩm.";
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleStatus(int id)
    {
        var product = await db.Products.FindAsync(id);
        if (product == null) return NotFound();

        product.Status = product.Status == 1 ? (byte)0 : (byte)1;
        await db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadCategories(int? selected = null)
    {
        ViewBag.Categories = new SelectList(
            await db.Categories.Where(c => c.Status == 1).OrderBy(c => c.Name).ToListAsync(),
            "Id", "Name", selected);
    }
}
