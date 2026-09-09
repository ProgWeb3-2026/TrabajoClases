using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Models;
using Examen.Data;

namespace Examen.Pages.TareaPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var tarea = await _context.Tarea.FindAsync(id);
        if (tarea != null)
        {
            Tarea = tarea;
            _context.Tarea.Remove(Tarea);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
