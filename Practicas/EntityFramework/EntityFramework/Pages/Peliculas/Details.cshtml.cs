using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.PeliculaPages;

public class DetailsModel : PageModel
{
    private readonly EntityFrameworkContext _context;
    public DetailsModel(EntityFrameworkContext context)
    {
        _context = context;
    }

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
}
