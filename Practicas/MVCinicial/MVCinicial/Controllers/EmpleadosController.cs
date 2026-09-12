
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCinicial.Models;
using MVCinicial.Data;

public class EmpleadosController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmpleadosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: EMPLEADOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Empleado.ToListAsync());
    }

    // GET: EMPLEADOS/Details/5
    public async Task<IActionResult> Details(int? idempleau)
    {
        if (idempleau == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleado
            .FirstOrDefaultAsync(m => m.IdEmpleau == idempleau);
        if (empleado == null)
        {
            return NotFound();
        }

        return View(empleado);
    }

    // GET: EMPLEADOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: EMPLEADOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdEmpleau,Nombre,Apellido,Sueldo,CorreoElectronico,Password,FechaNacimiento")] Empleado empleado)
    {
        if (ModelState.IsValid)
        {
            _context.Add(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(empleado);
    }

    // GET: EMPLEADOS/Edit/5
    public async Task<IActionResult> Edit(int? idempleau)
    {
        if (idempleau == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleado.FindAsync(idempleau);
        if (empleado == null)
        {
            return NotFound();
        }
        return View(empleado);
    }

    // POST: EMPLEADOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? idempleau, [Bind("IdEmpleau,Nombre,Apellido,Sueldo,CorreoElectronico,Password,FechaNacimiento")] Empleado empleado)
    {
        if (idempleau != empleado.IdEmpleau)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(empleado);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(empleado.IdEmpleau))
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
        return View(empleado);
    }

    // GET: EMPLEADOS/Delete/5
    public async Task<IActionResult> Delete(int? idempleau)
    {
        if (idempleau == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleado
            .FirstOrDefaultAsync(m => m.IdEmpleau == idempleau);
        if (empleado == null)
        {
            return NotFound();
        }

        return View(empleado);
    }

    // POST: EMPLEADOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? idempleau)
    {
        var empleado = await _context.Empleado.FindAsync(idempleau);
        if (empleado != null)
        {
            _context.Empleado.Remove(empleado);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmpleadoExists(int? idempleau)
    {
        return _context.Empleado.Any(e => e.IdEmpleau == idempleau);
    }
}
