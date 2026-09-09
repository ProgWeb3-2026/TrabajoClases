using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Practica3.Models;
using Practica3.Data;

namespace Practica3.Pages.CursoPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Curso Curso { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var curso = await _context.Cursos.FirstOrDefaultAsync(m => m.Id == id);
        if (curso is null)
        {
            return NotFound();
        }
        else
        {
            Curso = curso;
        }

        return Page();
    }
}
