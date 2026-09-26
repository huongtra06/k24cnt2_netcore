
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LHT2410900076_exam.Models;

public class LHTEmployeesController : Controller
{
    private readonly LHTEmployees2410900076Context _context;

    public LHTEmployeesController(LHTEmployees2410900076Context context)
    {
        _context = context;
    }

    // GET: LHTEMPLOYEES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.LHTEmployees.ToListAsync());
    }

    // GET: LHTEMPLOYEES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lhtemployee = await _context.LHTEmployees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lhtemployee == null)
        {
            return NotFound();
        }

        return View(lhtemployee);
    }

    // GET: LHTEMPLOYEES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LHTEMPLOYEES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,LHTName,LHTGender,LHTBirthDay,LHTEmail,LHTPhone,LHTActive")] LHTEmployees lhtemployee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(lhtemployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(lhtemployee);
    }

    // GET: LHTEMPLOYEES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lhtemployee = await _context.LHTEmployees.FindAsync(id);
        if (lhtemployee == null)
        {
            return NotFound();
        }
        return View(lhtemployee);
    }

    // POST: LHTEMPLOYEES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,LHTName,LHTGender,LHTBirthDay,LHTEmail,LHTPhone,LHTActive")] LHTEmployees lhtemployee)
    {
        if (id != lhtemployee.Id)
        {
            return NotFound();
        }

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
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(lhtemployee);
    }

    // GET: LHTEMPLOYEES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lhtemployee = await _context.LHTEmployees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lhtemployee == null)
        {
            return NotFound();
        }

        return View(lhtemployee);
    }

    // POST: LHTEMPLOYEES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var lhtemployee = await _context.LHTEmployees.FindAsync(id);
        if (lhtemployee != null)
        {
            _context.LHTEmployees.Remove(lhtemployee);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LHTEmployeeExists(int? id)
    {
        return _context.LHTEmployees.Any(e => e.Id == id);
    }
}
