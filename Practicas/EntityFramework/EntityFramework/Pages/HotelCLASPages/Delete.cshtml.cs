using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.HotelCLASPages;

public class DeleteModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public DeleteModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var hotelclas = await _context.HotelCLAs.FindAsync(id);
        if (hotelclas != null)
        {
            HotelCLAS = hotelclas;
            _context.HotelCLAs.Remove(HotelCLAS);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
