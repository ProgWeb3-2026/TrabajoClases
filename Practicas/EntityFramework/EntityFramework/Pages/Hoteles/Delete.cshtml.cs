using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.HotelPages;

public class DeleteModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public DeleteModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Hotel Hotel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var hotel = await _context.Hotel.FirstOrDefaultAsync(m => m.Id == id);
        if (hotel is null)
        {
            return NotFound();
        }
        else
        {
            Hotel = hotel;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var hotel = await _context.Hotel.FindAsync(id);
        if (hotel != null)
        {
            Hotel = hotel;
            _context.Hotel.Remove(Hotel);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
