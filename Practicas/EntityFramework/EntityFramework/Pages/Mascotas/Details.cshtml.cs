using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.MascotaPages;

public class DetailsModel : PageModel
{
    private readonly EntityFrameworkContext _context;
    public DetailsModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    public Mascota Mascota { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mascota = await _context.Mascota.FirstOrDefaultAsync(m => m.Id == id);
        if (mascota is null)
        {
            return NotFound();
        }
        else
        {
            Mascota = mascota;
        }

        return Page();
    }
}
