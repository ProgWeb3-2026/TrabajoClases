using Clase04_Practica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase04_Practica.Pages.Materias;

public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? SemestreFiltro { get; set; }

    public List<Materia> Materias { get; private set; } = [];
    public List<string> Semestres { get; private set; } = [];

    public void OnGet()
    {
        Semestres = MateriasRepo.Semestres();
        Materias  = string.IsNullOrEmpty(SemestreFiltro)
            ? MateriasRepo.Lista
            : MateriasRepo.Lista.Where(m => m.Semestre == SemestreFiltro).ToList();
    }
}
