using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Models;
using Examen.Data;

namespace Examen.Pages.InmueblePages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Inmueble> Inmueble { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Inmueble = await _context.Inmuebke.ToListAsync();
    }
}
