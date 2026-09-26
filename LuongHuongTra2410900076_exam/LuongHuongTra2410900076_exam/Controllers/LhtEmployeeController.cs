using LuongHuongTra2410900076_exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuongHuongTra2410900076_exam.Controllers;

public class LhtEmployeeController : Controller
{
    private readonly Lht_2410900076Context _context;

    public LhtEmployeeController(Lht_2410900076Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.LhtEmployees.AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var employee = await _context.LhtEmployees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (employee == null) return NotFound();
        return View(employee);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LhtEmployee employee)
    {
        if (!ModelState.IsValid) return View(employee);
        _context.LhtEmployees.Add(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var employee = await _context.LhtEmployees.FindAsync(id);
        if (employee == null) return NotFound();
        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LhtEmployee employee)
    {
        if (id != employee.Id) return NotFound();
        if (!ModelState.IsValid) return View(employee);
        try
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.LhtEmployees.AnyAsync(x => x.Id == employee.Id)) return NotFound();
            throw;
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var employee = await _context.LhtEmployees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (employee == null) return NotFound();
        return View(employee);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var employee = await _context.LhtEmployees.FindAsync(id);
        if (employee != null)
        {
            _context.LhtEmployees.Remove(employee);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
