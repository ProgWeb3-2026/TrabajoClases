namespace Clase04_Demo.Models;

// Modelo simple para demostrar paso de modelo a vistas parciales.
public class Noticia
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Resumen { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public bool Destacada { get; set; }
}

public static class NoticiasData
{
    public static List<Noticia> Lista =>
    [
        new() { Id = 1, Titulo = "ASP.NET Core 10 lanzado",    Resumen = "Nueva versión LTS con mejoras de rendimiento.", Categoria = "Tecnología", Fecha = new DateTime(2026, 1, 15), Destacada = true  },
        new() { Id = 2, Titulo = "Razor Pages en producción",  Resumen = "Casos de uso reales de Razor Pages en empresas.", Categoria = "Tutorial",    Fecha = new DateTime(2026, 2, 3),  Destacada = false },
        new() { Id = 3, Titulo = "Bootstrap 5 y .NET",        Resumen = "Integración de Bootstrap con proyectos ASP.NET.", Categoria = "Diseño",      Fecha = new DateTime(2026, 3, 10), Destacada = true  },
        new() { Id = 4, Titulo = "Tag Helpers en Razor",      Resumen = "Guía completa de Tag Helpers ASP.NET Core.",    Categoria = "Tutorial",    Fecha = new DateTime(2026, 4, 22), Destacada = false },
    ];
}
