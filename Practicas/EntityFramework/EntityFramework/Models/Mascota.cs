using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        
        public string Nombre { get; set; }
        public string Especie { get; set; }


        [Required]
        public string Raza { get; set; }

        [Range(0, 100)]
        public int Edad { get; set; }

        public decimal Peso { get; set; }

        [Required]
        public bool EsDomestica { get; set; }
    }
}
