using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.PeliculaPages;

public class DeleteModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public DeleteModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Pelicula Pelicula { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var pelicula = await _context.Pelicula.FirstOrDefaultAsync(m => m.Id == id);
        if (pelicula is null)
        {
            return NotFound();
        }
        else
        {
            Pelicula = pelicula;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var pelicula = await _context.Pelicula.FindAsync(id);
        if (pelicula != null)
        {
            Pelicula = pelicula;
            _context.Pelicula.Remove(Pelicula);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
