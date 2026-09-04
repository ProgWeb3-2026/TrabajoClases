using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Data;
using EntityFramework.Models;

namespace EntityFramework.Pages.mascotas
{
    public class DetailsModel : PageModel
    {
        private readonly EntityFramework.Data.EntityFrameworkContext _context;

        public DetailsModel(EntityFramework.Data.EntityFrameworkContext context)
        {
            _context = context;
        }

        public Mascota Mascota { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascota.FirstOrDefaultAsync(m => m.Id == id);

            if (mascota is not null)
            {
                Mascota = mascota;

                return Page();
            }

            return NotFound();
        }
    }
}
