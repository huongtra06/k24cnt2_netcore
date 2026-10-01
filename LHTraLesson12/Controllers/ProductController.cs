using LHTraLesson12.AppDBContext;
using LHTraLesson12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LHTraLesson12.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index(string? search, int? categoryId)
        {
            var query = _context.Products.Include(p => p.Category).AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(search)) query = query.Where(p => p.Name.Contains(search));
            if (categoryId.HasValue) query = query.Where(p => p.CategoryId == categoryId.Value);
            ViewBag.Search = search;
            ViewBag.CategoryId = categoryId;
            ViewBag.Categories = new SelectList(await _context.Categories.Where(c => c.Status == 1).OrderBy(c => c.Name).ToListAsync(), "Id", "Name", categoryId);
            return View(await query.OrderByDescending(p => p.Id).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.Include(p => p.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return product == null ? NotFound() : View(product);
        }

        public async Task<IActionResult> Create()
        {
            await LoadCategories();
            return View(new Product { Status = 1, CreatedDate = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ValidateProduct(product);
            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId && c.Status == 1))
                ModelState.AddModelError(nameof(product.CategoryId), "Vui lòng chọn danh mục.");

            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Now;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã thêm sản phẩm.";
                return RedirectToAction(nameof(Index));
            }
            await LoadCategories(product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            await LoadCategories(product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id) return NotFound();
            ValidateProduct(product);
            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId && c.Status == 1))
                ModelState.AddModelError(nameof(product.CategoryId), "Vui lòng chọn danh mục.");

            if (ModelState.IsValid)
            {
                var old = await _context.Products.FindAsync(id);
                if (old == null) return NotFound();
                old.Name = product.Name;
                old.Image = product.Image;
                old.Price = product.Price;
                old.SalePrice = product.SalePrice;
                old.Status = product.Status;
                old.Descriptions = product.Descriptions;
                old.CategoryId = product.CategoryId;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã cập nhật sản phẩm.";
                return RedirectToAction(nameof(Index));
            }
            await LoadCategories(product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.Include(p => p.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã xóa sản phẩm.";
            }
            return RedirectToAction(nameof(Index));
        }

        private void ValidateProduct(Product product)
        {
            if (product.Price < 0) ModelState.AddModelError(nameof(product.Price), "Giá không hợp lệ.");
            if (product.SalePrice < 0) ModelState.AddModelError(nameof(product.SalePrice), "Giá khuyến mãi không hợp lệ.");
            if (product.SalePrice > 0 && product.SalePrice >= product.Price)
                ModelState.AddModelError(nameof(product.SalePrice), "Giá khuyến mãi phải thấp hơn giá bán.");
        }

        private async Task LoadCategories(int? selected = null)
        {
            ViewBag.Categories = new SelectList(await _context.Categories.Where(c => c.Status == 1).OrderBy(c => c.Name).ToListAsync(), "Id", "Name", selected);
        }
    }
}
