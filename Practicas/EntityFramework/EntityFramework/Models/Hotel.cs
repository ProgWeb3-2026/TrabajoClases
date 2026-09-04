using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Hotel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Nombre es un campo requerido")]
        [StringLength(150, ErrorMessage = "Maximo 150")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ciudad es un campo requerido")]
        [StringLength(200, ErrorMessage = "Maximo 200")]
        public string Ciudad { get; set; } = string.Empty;

        [Required]
        [Range(0, 6)]
        public int CategoriaEstrellas { get; set; }

        [Required]
        [Range(1, 99999.99)]
        public decimal PrecioPorNoche { get; set; }

        public bool? Disponible { get; set; }
    }
}

