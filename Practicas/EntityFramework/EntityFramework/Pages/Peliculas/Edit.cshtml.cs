using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.PeliculaPages;

public class EditModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public EditModel(EntityFrameworkContext context)
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
        Pelicula = pelicula;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Pelicula).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PeliculaExists(Pelicula.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool PeliculaExists(int? id)
    {
        return _context.Pelicula.Any(e => e.Id == id);
    }
}
