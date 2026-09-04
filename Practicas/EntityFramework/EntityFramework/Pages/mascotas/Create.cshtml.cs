using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EntityFramework.Data;
using EntityFramework.Models;

namespace EntityFramework.Pages.mascotas
{
    public class CreateModel : PageModel
    {
        private readonly EntityFramework.Data.EntityFrameworkContext _context;

        public CreateModel(EntityFramework.Data.EntityFrameworkContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mascota Mascota { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mascota.Add(Mascota);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
