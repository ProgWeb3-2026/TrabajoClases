using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.HotelPages;

public class EditModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public EditModel(EntityFrameworkContext context)
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
        Hotel = hotel;
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

        _context.Attach(Hotel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HotelExists(Hotel.Id))
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

    private bool HotelExists(int? id)
    {
        return _context.Hotel.Any(e => e.Id == id);
    }
}
