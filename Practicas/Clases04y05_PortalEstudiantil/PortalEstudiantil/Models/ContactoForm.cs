using System.ComponentModel.DataAnnotations;

namespace PortalEstudiantil.Models;

public class ContactoForm
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Mínimo 2 caracteres.")]
    [Display(Name = "Nombre completo")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "Ingrese un email válido.")]
    [Display(Name = "Correo electrónico")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "El asunto es obligatorio.")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "Mínimo 5 caracteres.")]
    [Display(Name = "Asunto")]
    public string Asunto { get; set; } = string.Empty;

    [Required(ErrorMessage = "El mensaje es obligatorio.")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Mínimo 10 caracteres.")]
    [Display(Name = "Mensaje")]
    public string Mensaje { get; set; } = string.Empty;
}
