namespace PortalEstudiantil.Models;

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
