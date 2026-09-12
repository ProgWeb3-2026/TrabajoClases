using System.ComponentModel.DataAnnotations;

namespace MVCinicial.Models
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }

        [StringLength(100)]
        public string Nombre {  get; set; }
    }
}
