using Clase03_Demo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase03_Demo.Pages;

// Clase 3 — Tema 1.3.1: ¿Qué son Razor Pages?
//
// Un PageModel es la clase "code-behind" de una página Razor.
// Convención de nombres:
//   Index.cshtml      ↔  IndexModel (en Index.cshtml.cs)
//   Contacto.cshtml   ↔  ContactoModel (en Contacto.cshtml.cs)
//
// La clase DEBE heredar de PageModel.
// PageModel provee acceso a: HttpContext, Request, Response, RouteData,
// TempData, ViewData, Page(), RedirectToPage(), etc.
public class IndexModel : PageModel
{
    // Propiedades que la vista (.cshtml) leerá con @Model.Propiedad
    public int TotalProductos { get; private set; }
    public int ProductosDisponibles { get; private set; }
    public List<string> Categorias { get; private set; } = [];

    // OnGet() se ejecuta automáticamente en peticiones GET.
    // También existen: OnPost(), OnGetAsync(), OnPostAsync()
    public void OnGet()
    {
        TotalProductos = ProductosData.Lista.Count;
        ProductosDisponibles = ProductosData.Lista.Count(p => p.Disponible);
        Categorias = ProductosData.Categorias();
    }
}
