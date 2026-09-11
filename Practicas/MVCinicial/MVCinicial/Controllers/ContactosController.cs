
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCinicial.Models;
using MVCinicial.Data;

public class ContactosController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContactosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CONTACTOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Contacto.ToListAsync());
    }

    // GET: CONTACTOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contacto = await _context.Contacto
            .FirstOrDefaultAsync(m => m.Id == id);
        if (contacto == null)
        {
            return NotFound();
        }

        return View(contacto);
    }

    // GET: CONTACTOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CONTACTOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre")] Contacto contacto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(contacto);
    }

    // GET: CONTACTOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contacto = await _context.Contacto.FindAsync(id);
        if (contacto == null)
        {
            return NotFound();
        }
        return View(contacto);
    }

    // POST: CONTACTOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre")] Contacto contacto)
    {
        if (id != contacto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(contacto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoExists(contacto.Id))
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
        return View(contacto);
    }

    // GET: CONTACTOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contacto = await _context.Contacto
            .FirstOrDefaultAsync(m => m.Id == id);
        if (contacto == null)
        {
            return NotFound();
        }

        return View(contacto);
    }

    // POST: CONTACTOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var contacto = await _context.Contacto.FindAsync(id);
        if (contacto != null)
        {
            _context.Contacto.Remove(contacto);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ContactoExists(int? id)
    {
        return _context.Contacto.Any(e => e.Id == id);
    }
}
