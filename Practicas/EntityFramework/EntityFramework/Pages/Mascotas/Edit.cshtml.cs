using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.MascotaPages;

public class EditModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public EditModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    [BindProperty]
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
        Mascota = mascota;
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

        _context.Attach(Mascota).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MascotaExists(Mascota.Id))
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

    private bool MascotaExists(int id)
    {
        return _context.Mascota.Any(e => e.Id == id);
    }
}
