using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Data;
using EntityFramework.Models;

namespace EntityFramework.Pages.hoteles
{
    public class DeleteModel : PageModel
    {
        private readonly EntityFramework.Data.EntityFrameworkContext _context;

        public DeleteModel(EntityFramework.Data.EntityFrameworkContext context)
        {
            _context = context;
        }

        [BindProperty]
        public hotel hotel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.hotel.FirstOrDefaultAsync(m => m.Id == id);

            if (hotel is not null)
            {
                hotel = hotel;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.hotel.FindAsync(id);
            if (hotel != null)
            {
                hotel = hotel;
                _context.hotel.Remove(hotel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
