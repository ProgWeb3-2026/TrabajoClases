using System.ComponentModel.DataAnnotations;

namespace Practica3.Models
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Titulo es un campo requerido")]
        [StringLength(200, ErrorMessage = "Maximo de 200")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Resumen es un campo requerido")]
        [StringLength(500, ErrorMessage = "Maximo de 500")]
        public string Resumen { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Autor es un campo requerido")]
        [StringLength(100, ErrorMessage = "Maximo de 100")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Fecha de publicacion es un campo requerido")]
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "La Categoria es un campo requerido")]
        [StringLength(100, ErrorMessage = "Maximo de 100")]
        public string Categoria { get; set; } = string.Empty;

        public bool Publicado { get; set; }
    }
}
