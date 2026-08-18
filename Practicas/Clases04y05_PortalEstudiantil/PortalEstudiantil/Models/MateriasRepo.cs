namespace PortalEstudiantil.Models;

public static class MateriasRepo
{
    public static List<Materia> Lista =>
    [
        new() { Id = 1, Nombre = "Programación Web I",   Descripcion = "HTML, CSS y fundamentos del desarrollo web.",               Docente = "Ing. García",    HorasSemanales = 4, Semestre = "3°", Icono = "🌐", Activa = true  },
        new() { Id = 2, Nombre = "Programación Web II",  Descripcion = "JavaScript, DOM, eventos y frameworks front-end.",          Docente = "Ing. López",     HorasSemanales = 4, Semestre = "4°", Icono = "⚡", Activa = true  },
        new() { Id = 3, Nombre = "Programación Web III", Descripcion = "ASP.NET Core, Razor Pages y desarrollo back-end con C#.",   Docente = "Ing. V. Ortega", HorasSemanales = 4, Semestre = "5°", Icono = "🔷", Activa = true  },
        new() { Id = 4, Nombre = "Base de Datos I",      Descripcion = "Modelo relacional, normalización y SQL.",                   Docente = "Ing. Mamani",    HorasSemanales = 3, Semestre = "3°", Icono = "🗄️", Activa = true  },
        new() { Id = 5, Nombre = "Base de Datos II",     Descripcion = "Procedimientos almacenados, triggers y bases NoSQL.",       Docente = "Ing. Mamani",    HorasSemanales = 3, Semestre = "4°", Icono = "📊", Activa = false },
        new() { Id = 6, Nombre = "Estructura de Datos",  Descripcion = "Listas, pilas, colas, árboles y grafos en C#.",             Docente = "Ing. Condori",   HorasSemanales = 4, Semestre = "2°", Icono = "🌲", Activa = true  },
    ];

    public static Materia? BuscarPorId(int id) =>
        Lista.FirstOrDefault(m => m.Id == id);

    public static List<string> Semestres() =>
        Lista.Select(m => m.Semestre).Distinct().Order().ToList();
}
