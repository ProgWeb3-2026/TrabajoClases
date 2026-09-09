using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Models;
using Examen.Data;

namespace Examen.Pages.TareaPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Tarea Tarea { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var tarea = await _context.Tarea.FirstOrDefaultAsync(m => m.Id == id);
        if (tarea is null)
        {
            return NotFound();
        }
        else
        {
            Tarea = tarea;
        }

        return Page();
    }
}
