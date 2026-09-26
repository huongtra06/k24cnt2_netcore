using LHT2410900076_exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LHT2410900076_exam.Controllers;

public class LHTEmployeesController : Controller
{
    private readonly LHTEmployee2410900076Context _context;

    public LHTEmployeesController(LHTEmployee2410900076Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.LHTEmployees.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var lhtemployee = await _context.LHTEmployees
            .FirstOrDefaultAsync(m => m.Id == id);

        if (lhtemployee == null)
            return NotFound();

        return View(lhtemployee);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,LHTName,LHTGender,LHTBirthDay,LHTEmail,LHTPhone,LHTActive")] LHTEmployee lhtemployee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(lhtemployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(lhtemployee);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var lhtemployee = await _context.LHTEmployees.FindAsync(id);

        if (lhtemployee == null)
            return NotFound();

        return View(lhtemployee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,LHTName,LHTGender,LHTBirthDay,LHTEmail,LHTPhone,LHTActive")] LHTEmployee lhtemployee)
    {
        if (id != lhtemployee.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(lhtemployee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LHTEmployeeExists(lhtemployee.Id))
                    return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(lhtemployee);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var lhtemployee = await _context.LHTEmployees
            .FirstOrDefaultAsync(m => m.Id == id);

        if (lhtemployee == null)
            return NotFound();

        return View(lhtemployee);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var lhtemployee = await _context.LHTEmployees.FindAsync(id);

        if (lhtemployee != null)
        {
            _context.LHTEmployees.Remove(lhtemployee);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool LHTEmployeeExists(int id)
    {
        return _context.LHTEmployees.Any(e => e.Id == id);
    }
}
