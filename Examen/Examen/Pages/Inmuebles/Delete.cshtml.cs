using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Models;
using Examen.Data;

namespace Examen.Pages.InmueblePages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Inmueble Inmueble { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var inmueble = await _context.Inmuebke.FirstOrDefaultAsync(m => m.id == id);
        if (inmueble is null)
        {
            return NotFound();
        }
        else
        {
            Inmueble = inmueble;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var inmueble = await _context.Inmuebke.FindAsync(id);
        if (inmueble != null)
        {
            Inmueble = inmueble;
            _context.Inmuebke.Remove(Inmueble);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
