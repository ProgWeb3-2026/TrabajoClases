using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practica3.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es un campo requerido")]
        [StringLength(200, ErrorMessage = "Maximo de 200")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Maximo de 500")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El Instructor es un campo requerido")]
        [StringLength(200, ErrorMessage = "Maximo de 200")]
        public string Instructor { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Duracion en horas es un campo requerido")]
        [Range(1, 1000, ErrorMessage = "Debe estar entre 1 y 1000")]
        public int DuracionHoras { get; set; }

        [Required(ErrorMessage = "El Precio es un campo requerido")]
        [Range(0, 1000000, ErrorMessage = "El precio debe estar entre 0 y 1000000")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El Nivel es un campo requerido")]
        [StringLength(50, ErrorMessage = "Maximo de 50")]
        public string Nivel { get; set; } = string.Empty;
    }
}
