using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase03_Demo.Pages;

// Clase 3 — Tema 1.3.2: Sintaxis Razor
//
// Esta página demuestra las construcciones de sintaxis Razor más importantes.
// La vista (.cshtml) las usa todas; el PageModel solo provee los datos.
public class SintaxisRazorModel : PageModel
{
    // Datos simples que la vista usará para demostrar cada construcción Razor
    public string Saludo { get; private set; } = string.Empty;
    public int Numero { get; private set; }
    public bool EsActivo { get; private set; }
    public List<string> Lenguajes { get; private set; } = [];
    public Dictionary<string, int> Notas { get; private set; } = [];
    public DateTime FechaHoy { get; private set; }

    // [BindProperty] enlaza la propiedad con el campo del formulario POST automáticamente.
    // SupportsGet=true permite usarla también en peticiones GET (query string).
    [BindProperty(SupportsGet = true)]
    public string? NombreIngresado { get; set; }

    public void OnGet()
    {
        FechaHoy = DateTime.Now;
        Numero = 7;
        EsActivo = true;

        // El saludo cambia si el usuario envió su nombre por query string (?NombreIngresado=...)
        Saludo = string.IsNullOrEmpty(NombreIngresado)
            ? "Estudiante PRW3"
            : NombreIngresado;

        Lenguajes = ["C#", "JavaScript", "TypeScript", "Python", "SQL"];

        Notas = new Dictionary<string, int>
        {
            ["Alice"] = 85,
            ["Bob"]   = 92,
            ["Carol"] = 73,
            ["David"] = 88,
        };
    }
}
