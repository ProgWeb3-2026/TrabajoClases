using PortalEstudiantil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortalEstudiantil.Pages;

public class ContactoModel : PageModel
{
    [BindProperty]
    public ContactoForm Formulario { get; set; } = new();

    public static List<ContactoForm> MensajesEnviados { get; } = [];

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        MensajesEnviados.Add(Formulario);
        TempData["MensajeOk"] = $"Gracias, {Formulario.Nombre}. Tu mensaje fue recibido.";
        return RedirectToPage();
    }
}
