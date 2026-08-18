using Clase04_Demo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase04_Demo.Pages.Demos;

// Tema 1.4.3 — Vistas Parciales
// Demuestra: <partial name="..." model="@item" />, Html.PartialAsync, modelo tipado.
public class ParcialesModel : PageModel
{
    public List<Noticia> Noticias { get; private set; } = [];

    public void OnGet()
    {
        Noticias = NoticiasData.Lista;
    }
}
