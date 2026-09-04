using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.HotelCLASPages;

public class DetailsModel : PageModel
{
    private readonly EntityFrameworkContext _context;
    public DetailsModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    public HotelCLAS HotelCLAS { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var hotelclas = await _context.HotelCLAs.FirstOrDefaultAsync(m => m.id == id);
        if (hotelclas is null)
        {
            return NotFound();
        }
        else
        {
            HotelCLAS = hotelclas;
        }

        return Page();
    }
}
