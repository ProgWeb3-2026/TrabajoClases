using PortalEstudiantil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortalEstudiantil.Pages.Materias;

public class DetalleModel : PageModel
{
    public Materia Materia { get; private set; } = null!;
    public Materia? Anterior { get; private set; }
    public Materia? Siguiente { get; private set; }
    public List<Materia> OtrasMaterias { get; private set; } = [];

    public IActionResult OnGet(int id)
    {
        var materia = MateriasRepo.BuscarPorId(id);
        if (materia is null)
            return NotFound();

        Materia = materia;

        var todas = MateriasRepo.Lista;
        var idx   = todas.FindIndex(m => m.Id == id);
        Anterior  = idx > 0               ? todas[idx - 1] : null;
        Siguiente = idx < todas.Count - 1 ? todas[idx + 1] : null;
        OtrasMaterias = todas.Where(m => m.Id != id).ToList();

        return Page();
    }
}
