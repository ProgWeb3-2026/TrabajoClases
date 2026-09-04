using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.HotelCLASPages;

public class IndexModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public IndexModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    public IList<HotelCLAS> HotelCLAS { get; set; } = default!;

    public async Task OnGetAsync()
    {
        HotelCLAS = await _context.HotelCLAs.ToListAsync();
    }
}
