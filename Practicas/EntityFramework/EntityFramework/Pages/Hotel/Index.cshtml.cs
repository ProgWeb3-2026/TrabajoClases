using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Pages.HotelPages;

public class IndexModel : PageModel
{
    private readonly EntityFrameworkContext _context;

    public IndexModel(EntityFrameworkContext context)
    {
        _context = context;
    }

    public IList<ClaseHotel> Hotel { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Hotel = await _context.Hotel.ToListAsync();
    }
}
