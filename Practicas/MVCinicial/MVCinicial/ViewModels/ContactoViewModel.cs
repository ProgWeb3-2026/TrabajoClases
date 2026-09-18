using System.ComponentModel.DataAnnotations;

namespace MVCinicial.ViewModels
{
    public class ContactoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Contacto")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
