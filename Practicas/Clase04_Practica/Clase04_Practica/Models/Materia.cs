namespace Clase04_Practica.Models;

public class Materia
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Docente { get; set; } = string.Empty;
    public int HorasSemanales { get; set; }
    public string Semestre { get; set; } = string.Empty;
    public string Icono { get; set; } = "📚";
    public bool Activa { get; set; } = true;
}

public static class MateriasRepo
{
    public static List<Materia> Lista =>
    [
        new() { Id = 1, Nombre = "Programación Web I",      Descripcion = "HTML, CSS y fundamentos de la web.",                  Docente = "Ing. García",   HorasSemanales = 4, Semestre = "3°", Icono = "🌐", Activa = true  },
        new() { Id = 2, Nombre = "Programación Web II",     Descripcion = "JavaScript, DOM y frameworks front-end.",             Docente = "Ing. López",    HorasSemanales = 4, Semestre = "4°", Icono = "⚡", Activa = true  },
        new() { Id = 3, Nombre = "Programación Web III",    Descripcion = "ASP.NET Core, Razor Pages y desarrollo back-end.",    Docente = "Ing. V. Ortega",HorasSemanales = 4, Semestre = "5°", Icono = "🔷", Activa = true  },
        new() { Id = 4, Nombre = "Base de Datos I",         Descripcion = "Modelo relacional, SQL y diseño de esquemas.",        Docente = "Ing. Mamani",   HorasSemanales = 3, Semestre = "3°", Icono = "🗄️", Activa = true  },
        new() { Id = 5, Nombre = "Base de Datos II",        Descripcion = "Procedimientos almacenados, triggers y NoSQL.",       Docente = "Ing. Mamani",   HorasSemanales = 3, Semestre = "4°", Icono = "📊", Activa = true  },
        new() { Id = 6, Nombre = "Estructura de Datos",     Descripcion = "Listas, pilas, colas, árboles y grafos.",             Docente = "Ing. Condori",  HorasSemanales = 4, Semestre = "2°", Icono = "🌲", Activa = false },
    ];

    public static Materia? BuscarPorId(int id) =>
        Lista.FirstOrDefault(m => m.Id == id);

    public static List<string> Semestres() =>
        Lista.Select(m => m.Semestre).Distinct().Order().ToList();
}
