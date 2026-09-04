using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.HotelCLASPages;

public class EditModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public EditModel(EntityFrameworkContext context)
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
        HotelCLAS = hotelclas;
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

        _context.Attach(HotelCLAS).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HotelCLASExists(HotelCLAS.id))
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

    private bool HotelCLASExists(int? id)
    {
        return _context.HotelCLAs.Any(e => e.id == id);
    }
}
