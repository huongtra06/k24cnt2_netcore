
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LHTLesson10EFDBFirst.Models;

public class LhtmembersController : Controller
{
    private readonly Lhtlesson10EfdbContext _context;

    public LhtmembersController(Lhtlesson10EfdbContext context)
    {
        _context = context;
    }

    // GET: LHTMEMBERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Lhtmembers.ToListAsync());
    }

    // GET: LHTMEMBERS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lhtmember = await _context.Lhtmembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lhtmember == null)
        {
            return NotFound();
        }

        return View(lhtmember);
    }

    // GET: LHTMEMBERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LHTMEMBERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Lhtusername,Lhtpassword,Lhtemail,Lhtphone,Lhtstatus")] Lhtmember lhtmember)
    {
        if (ModelState.IsValid)
        {
            _context.Add(lhtmember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(lhtmember);
    }

    // GET: LHTMEMBERS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lhtmember = await _context.Lhtmembers.FindAsync(id);
        if (lhtmember == null)
        {
            return NotFound();
        }
        return View(lhtmember);
    }

    // POST: LHTMEMBERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,Lhtusername,Lhtpassword,Lhtemail,Lhtphone,Lhtstatus")] Lhtmember lhtmember)
    {
        if (id != lhtmember.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(lhtmember);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LhtmemberExists(lhtmember.Id))
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
        return View(lhtmember);
    }

    // GET: LHTMEMBERS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lhtmember = await _context.Lhtmembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lhtmember == null)
        {
            return NotFound();
        }

        return View(lhtmember);
    }

    // POST: LHTMEMBERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var lhtmember = await _context.Lhtmembers.FindAsync(id);
        if (lhtmember != null)
        {
            _context.Lhtmembers.Remove(lhtmember);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LhtmemberExists(long? id)
    {
        return _context.Lhtmembers.Any(e => e.Id == id);
    }
}
