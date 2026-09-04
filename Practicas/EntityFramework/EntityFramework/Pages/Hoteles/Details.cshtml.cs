using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.HotelPages;

public class DetailsModel : PageModel
{
    private readonly EntityFrameworkContext _context;
    public DetailsModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    public Hotel Hotel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var hotel = await _context.Hoteles.FirstOrDefaultAsync(m => m.Id == id);
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
}
