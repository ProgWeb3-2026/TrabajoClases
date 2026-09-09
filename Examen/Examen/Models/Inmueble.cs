using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Inmueble
    {
        public int id { get; set; }

        [StringLength(50,ErrorMessage ="Debes ingresar el titulo")]
        [Required]      
        public string Titulo { get; set; }

        [StringLength(50, ErrorMessage = "Debes ingresar la descripcion ")]
        [Required(ErrorMessage ="Debes ingresar")]
        public string Descripcion { get; set; }

        [StringLength(50, ErrorMessage ="Ingrese el tipo ")]
        [Required(ErrorMessage = "Debes ingresar")]
        public string Tipo { get; set; }

        [Required(ErrorMessage ="Ingrese el precio")]
        public decimal Precio { get; set; }

        [Display(Name = "Disponible")]
        public bool Disponible { get; set; }
        public DateTime FechaPublicaion { get; set; }
    }
}
