using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCinicial.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleau {  get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
  
        public string? Apellido { get; set; }

        [Range(0,4000, ErrorMessage = "El sueldo es muy alto")]
        public int Sueldo { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El correo es requerido")]
        [Display(Name = "Email")]
        public string CorreoElectronico { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public int? IdCargo { get; set; }

        [ForeignKey("IdCargo")]
        public virtual Cargo Cargo { get; set; }
    }
}
