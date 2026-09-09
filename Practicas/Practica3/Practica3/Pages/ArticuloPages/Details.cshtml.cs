using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Practica3.Models;
using Practica3.Data;

namespace Practica3.Pages.ArticuloPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Articulo Articulo { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var articulo = await _context.Articulos.FirstOrDefaultAsync(m => m.Id == id);
        if (articulo is null)
        {
            return NotFound();
        }
        else
        {
            Articulo = articulo;
        }

        return Page();
    }
}
