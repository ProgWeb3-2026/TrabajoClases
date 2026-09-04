using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Hotel
    {
        public int? id { get; set; }

        [Required(ErrorMessage = "Nombre es un campo requerido")]
        [StringLength(150, ErrorMessage = "Maximo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage =  "Cuidad es un campo requerido ")]
        [StringLength(200, ErrorMessage = "Maximo 200")]
        public string Cuidad { get; set; }

        [Required]
        [Range(0,6)]
        public int CategoriaEstrellas { get; set; }

        [Required]
        [Range(1, 99999.99)]
        public decimal PrecioPorNoche { get; set; }
        public bool Disponible { get; set; }
    }
}
