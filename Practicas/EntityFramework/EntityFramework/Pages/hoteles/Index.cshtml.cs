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
    public class IndexModel : PageModel
    {
        private readonly EntityFramework.Data.EntityFrameworkContext _context;

        public IndexModel(EntityFramework.Data.EntityFrameworkContext context)
        {
            _context = context;
        }

        public IList<hotel> hotel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            hotel = await _context.hotel.ToListAsync();
        }
    }
}
