namespace Clase03_Demo.Models;

/// <summary>
/// Clase de modelo simple para demostrar Razor Pages.
/// No usa Entity Framework todavía — los datos son estáticos en memoria.
/// </summary>
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public bool Disponible { get; set; }
    public string? Descripcion { get; set; }
}

/// <summary>
/// Repositorio en memoria para la demo.
/// Simula una fuente de datos sin necesitar base de datos.
/// En la Unidad 2 y 3 esto será reemplazado por EF Core + BD real.
/// </summary>
public static class ProductosData
{
    public static readonly List<Producto> Lista = new()
    {
        new() { Id = 1, Nombre = "Laptop ProBook",  Categoria = "Electrónica", Precio = 4500.00m, Stock = 10, Disponible = true,  Descripcion = "Laptop de alto rendimiento con procesador de 12a generación." },
        new() { Id = 2, Nombre = "Mouse Inalámbrico", Categoria = "Electrónica", Precio = 150.00m, Stock = 50, Disponible = true,  Descripcion = "Mouse ergonómico con receptor USB." },
        new() { Id = 3, Nombre = "Teclado Mecánico", Categoria = "Electrónica", Precio = 320.00m, Stock = 0,  Disponible = false, Descripcion = "Teclado mecánico retroiluminado, switches blue." },
        new() { Id = 4, Nombre = "Escritorio Modular", Categoria = "Mobiliario", Precio = 1200.00m, Stock = 5, Disponible = true,  Descripcion = "Escritorio de madera con compartimentos organizadores." },
        new() { Id = 5, Nombre = "Silla Ergonómica", Categoria = "Mobiliario", Precio = 890.00m, Stock = 8, Disponible = true,  Descripcion = "Silla con soporte lumbar y altura ajustable." },
        new() { Id = 6, Nombre = "Monitor 27\"",      Categoria = "Electrónica", Precio = 2100.00m, Stock = 3, Disponible = true,  Descripcion = "Monitor IPS 4K con frecuencia de 144Hz." },
    };

    public static Producto? BuscarPorId(int id) =>
        Lista.FirstOrDefault(p => p.Id == id);

    public static List<Producto> BuscarPorCategoria(string categoria) =>
        Lista.Where(p => p.Categoria == categoria).ToList();

    public static List<string> Categorias() =>
        Lista.Select(p => p.Categoria).Distinct().OrderBy(c => c).ToList();
}
