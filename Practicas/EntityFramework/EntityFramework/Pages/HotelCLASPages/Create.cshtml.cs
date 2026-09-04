using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.HotelCLASPages;

public class CreateModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public CreateModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public HotelCLAS HotelCLAS { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.HotelCLAs.Add(HotelCLAS);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
