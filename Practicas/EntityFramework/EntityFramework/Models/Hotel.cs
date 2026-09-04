using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Hotel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Nombre es un campo requerido")]
        [StringLength(150,ErrorMessage = "Maximo de 150")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Nombre es un campo requerido")]
        [StringLength(150, ErrorMessage = "Maximo de 150")]
        public string Ciudad { get; set; }
        public int  CategoriaEstrellas { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public bool Disponible { get; set; }

    }
}