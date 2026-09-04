using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Pelicula
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(100, ErrorMessage = ("Maximo 100 caracteres"))]

        public string Titulo { get; set; }

        [StringLength(50, ErrorMessage = "El directo no puede superar los 50 caracteres")]
        public string? Director { get; set; }

        [Required(ErrorMessage = "El campo genero es obligatorio")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El maximo son 300 caracteres")]

        public string Genero { get; set; }

        [Required(ErrorMessage = "El campo precio es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser un número positivo")]
        [Display(Name = "Precio")]
        public int Anio { get; set; }

        [Display(Name = "Disponible")]
        public int DuracionMinutos { get; set; }
    }
}
