using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.MascotaPages;

public class IndexModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public IndexModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    public IList<Mascota> Mascota { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Mascota = await _context.Mascota.ToListAsync();
    }
}
