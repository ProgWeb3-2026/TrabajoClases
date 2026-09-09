using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Tarea
    {
        public int? Id { get; set; }

        [StringLength(50, ErrorMessage ="Debes ingresar el titulo ")]
        [Required]
        public string? Titulo { get; set; }

        [StringLength(50, ErrorMessage ="Debes ingresar descripcion")]
        [Required]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage ="Debes ingresar fecha de nacimiento")]
        public DateTime FechaVencimiento { get; set; }

        [StringLength(50, ErrorMessage ="Debes ingresar la categoria")]
        [Required]
        public string? Categoria { get; set; }
        public bool Publicado { get; set; }

    }
}
