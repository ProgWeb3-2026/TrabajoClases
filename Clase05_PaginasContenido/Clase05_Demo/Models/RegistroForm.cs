using System.ComponentModel.DataAnnotations;

namespace Clase05_Demo.Models;

// Modelo de formulario para demostrar [BindProperty] + DataAnnotations + ModelState.
// Las anotaciones definen las reglas de validación que ModelState.IsValid verifica.
public class RegistroForm
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Mínimo 2 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "Ingrese un email válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La carrera es obligatoria.")]
    public string Carrera { get; set; } = string.Empty;

    [Range(1, 10, ErrorMessage = "El semestre debe estar entre 1 y 10.")]
    public int Semestre { get; set; } = 1;
}
