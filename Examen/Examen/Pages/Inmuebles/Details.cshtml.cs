using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Models;
using Examen.Data;

namespace Examen.Pages.InmueblePages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

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
}
