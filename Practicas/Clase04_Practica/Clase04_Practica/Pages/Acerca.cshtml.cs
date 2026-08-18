using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase04_Practica.Pages;

public class AcercaModel : PageModel
{
    public List<string> Tecnologias { get; private set; } = [];

    public void OnGet()
    {
        Tecnologias =
        [
            "ASP.NET Core 10 — Razor Pages",
            "C# 12",
            "Bootstrap 5.3",
            ".NET 10",
            "_Layout.cshtml + Vistas Parciales",
        ];
    }
}
