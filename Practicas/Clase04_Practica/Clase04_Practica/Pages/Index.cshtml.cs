using Clase04_Practica.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase04_Practica.Pages;

public class IndexModel : PageModel
{
    public int TotalMaterias { get; private set; }
    public int MateriasActivas { get; private set; }
    public int TotalSemestres { get; private set; }
    public List<Materia> MateriasDestacadas { get; private set; } = [];

    public void OnGet()
    {
        TotalMaterias     = MateriasRepo.Lista.Count;
        MateriasActivas   = MateriasRepo.Lista.Count(m => m.Activa);
        TotalSemestres    = MateriasRepo.Semestres().Count;
        MateriasDestacadas = MateriasRepo.Lista.Where(m => m.Activa).Take(3).ToList();
    }
}
