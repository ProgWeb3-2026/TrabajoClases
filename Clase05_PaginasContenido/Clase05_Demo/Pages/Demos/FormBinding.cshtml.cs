using Clase05_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase05_Demo.Pages.Demos;

// Tema 1.5.1 — [BindProperty] + ModelState + DataAnnotations
// Demuestra el ciclo completo de un formulario POST con validación.
public class FormBindingModel : PageModel
{
    // [BindProperty] vincula automáticamente los campos del formulario con esta propiedad.
    // Razor Pages lee los campos del request HTTP POST y popula RegistroForm.
    [BindProperty]
    public RegistroForm Formulario { get; set; } = new();

    // Almacén en memoria para mostrar los registros enviados en esta sesión.
    public static List<RegistroForm> Registros { get; } = [];

    public void OnGet()
    {
        // GET: solo prepara la página. El formulario queda vacío.
    }

    public IActionResult OnPost()
    {
        // ModelState.IsValid verifica las [DataAnnotations] del modelo:
        //   [Required], [EmailAddress], [StringLength], [Range], etc.
        // Si alguna falla, ModelState contiene los errores para mostrar en la vista.
        if (!ModelState.IsValid)
        {
            // Page() re-muestra el formulario con los campos ya escritos
            // y los mensajes de error en cada asp-validation-for.
            return Page();
        }

        // Validación superada: procesar el formulario.
        Registros.Add(new RegistroForm
        {
            Nombre   = Formulario.Nombre,
            Email    = Formulario.Email,
            Carrera  = Formulario.Carrera,
            Semestre = Formulario.Semestre,
        });

        // TempData pasa el mensaje de éxito a través de la redirección.
        TempData["MensajeOk"] = $"Registro de {Formulario.Nombre} guardado correctamente.";

        // RedirectToPage() implementa el patrón POST-Redirect-GET:
        // evita que refrescar el navegador re-envíe el formulario.
        return RedirectToPage();
    }
}
