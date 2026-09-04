using Microsoft.Identity.Client.NativeInterop;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [StringLength(150, ErrorMessage = "Maximo 150")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ciudad es un campo requerido")]
        [StringLength(200, ErrorMessage = "Maximo 200")]
        public string Ciudad { get; set; }

        [Required]
        [Range(0, 6)]
        public int Categoria { get; set; }

        [Required]
        [Range(1, 99999.99)]
        public decimal PrecioPorNoche { get; set; }

        public bool Disponible { get; set; }
    }
}
