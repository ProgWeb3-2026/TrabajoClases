using Clase03_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase03_Demo.Pages.Productos;

// Clase 3 — Tema 1.3.3: Parámetros de ruta en Razor Pages
//
// La directiva @page "{id:int}" en la vista define un segmento de ruta.
// Ejemplo de URL: /Productos/Detalle/3  → id = 3
//
// El parámetro puede recibirse de dos formas:
//   A) Como parámetro del handler: public IActionResult OnGet(int id) { }
//   B) Como propiedad con [BindProperty(SupportsGet=true)]: ver abajo
public class DetalleModel : PageModel
{
    // Producto encontrado. Se inicializa como null! porque el compilador no sabe
    // que OnGet() solo llama Page() cuando ya fue asignado.
    public Producto Producto { get; private set; } = null!;

    // El id viene del segmento de ruta definido en @page "{id:int}"
    // SupportsGet=true permite recibirlo también como query: /Productos/Detalle?id=3
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    // OnGet puede retornar IActionResult en lugar de void.
    // Esto permite retornar NotFound(), RedirectToPage(), etc.
    public IActionResult OnGet()
    {
        Producto = ProductosData.BuscarPorId(Id);

        // Si el producto no existe, retornar 404
        // NotFound() es equivalente a return new NotFoundResult()
        if (Producto is null)
            return NotFound();

        // Page() renderiza la vista — equivalente a retornar void (comportamiento por defecto)
        return Page();
    }
}
