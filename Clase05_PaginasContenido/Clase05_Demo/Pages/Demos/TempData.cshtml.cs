using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase05_Demo.Pages.Demos;

// Tema 1.5.1 — TempData y patrón POST-Redirect-GET (PRG)
// Demuestra: TempData["clave"], ciclo de vida de una sola petición, PRG.
public class TempDataModel : PageModel
{
    [BindProperty]
    public string NombreAccion { get; set; } = string.Empty;

    public void OnGet()
    {
        // TempData["Resultado"] llega aquí después de la redirección.
        // Si viene de OnPost, ya está disponible para la vista.
        // Razor Pages lo borra automáticamente tras esta lectura.
    }

    // Handler "Guardar" — simula una acción exitosa
    public IActionResult OnPostGuardar()
    {
        TempData["Tipo"]      = "success";
        TempData["Resultado"] = $"✅ '{NombreAccion}' guardado correctamente.";
        return RedirectToPage();
    }

    // Handler "Eliminar" — simula una acción con advertencia
    public IActionResult OnPostEliminar()
    {
        TempData["Tipo"]      = "warning";
        TempData["Resultado"] = $"⚠️ '{NombreAccion}' eliminado. Esta acción no se puede deshacer.";
        return RedirectToPage();
    }

    // Handler "Error" — simula un error
    public IActionResult OnPostError()
    {
        TempData["Tipo"]      = "danger";
        TempData["Resultado"] = $"❌ Error al procesar '{NombreAccion}'. Intente de nuevo.";
        return RedirectToPage();
    }
}
