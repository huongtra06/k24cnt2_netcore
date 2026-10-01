using LHTraLesson12.AppDBContext;
using LHTraLesson12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LHTraLesson12.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Categories.Include(c => c.Products).OrderBy(c => c.Id).ToListAsync());

        public IActionResult Create() => View(new Category { Status = 1, CreateDate = DateTime.Now });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (await _context.Categories.AnyAsync(c => c.Name == category.Name))
                ModelState.AddModelError(nameof(category.Name), "Tên danh mục đã tồn tại.");
            if (ModelState.IsValid)
            {
                category.CreateDate = DateTime.Now;
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã thêm danh mục.";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var category = await _context.Categories.FindAsync(id);
            return category == null ? NotFound() : View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id) return NotFound();
            if (await _context.Categories.AnyAsync(c => c.Id != id && c.Name == category.Name))
                ModelState.AddModelError(nameof(category.Name), "Tên danh mục đã tồn tại.");
            if (ModelState.IsValid)
            {
                var old = await _context.Categories.FindAsync(id);
                if (old == null) return NotFound();
                old.Name = category.Name;
                old.Status = category.Status;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã cập nhật danh mục.";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var category = await _context.Categories.Include(c => c.Products).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return category == null ? NotFound() : View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return RedirectToAction(nameof(Index));
            if (category.Products.Any())
            {
                TempData["Error"] = "Danh mục đang có sản phẩm.";
                return RedirectToAction(nameof(Index));
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Đã xóa danh mục.";
            return RedirectToAction(nameof(Index));
        }
    }
}
