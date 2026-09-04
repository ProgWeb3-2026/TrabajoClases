using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.PeliculaPages;

public class IndexModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public IndexModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    public IList<Pelicula> Pelicula { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Pelicula = await _context.Pelicula.ToListAsync();
    }
}
