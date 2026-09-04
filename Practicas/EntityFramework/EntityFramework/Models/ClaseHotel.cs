using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class ClaseHotel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre es un campo Requerido")]
        [StringLength(100,ErrorMessage ="Maximo 100")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ciudad es un campo Requerido")]
        [StringLength(200, ErrorMessage = "Maximo 200")]
        public string Ciudad { get; set; }


        [Range(0, 100)]
        public int CategoriaEstrellas { get; set; }

        public decimal PrecioNoche { get; set; }

        [Required]
        public bool? Disponible { get; set; }
    }
}
