using Clase03_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase03_Demo.Pages.Productos;

// Clase 3 — Tema 1.3.3: Routing en Razor Pages
//
// Esta página demuestra el routing por convención de carpetas:
//   Archivo:  Pages/Productos/Index.cshtml
//   URL:      /Productos  (el nombre "Index" se omite en la URL)
//
// También demuestra el filtro con parámetro GET ([BindProperty SupportsGet])
// y el patrón OnGet() con lógica de filtrado.
public class IndexModel : PageModel
{
    public List<Producto> Productos { get; private set; } = [];
    public List<string> Categorias { get; private set; } = [];

    // SupportsGet=true → se puede leer desde la URL: /Productos?CategoriaFiltro=Electronica
    [BindProperty(SupportsGet = true)]
    public string? CategoriaFiltro { get; set; }

    public void OnGet()
    {
        Categorias = ProductosData.Categorias();

        // Filtrar por categoría si se especificó
        Productos = string.IsNullOrEmpty(CategoriaFiltro)
            ? ProductosData.Lista
            : ProductosData.BuscarPorCategoria(CategoriaFiltro);
    }
}
