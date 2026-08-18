# Portal Estudiantil — Clases 4 y 5
**Programación Web III | Universidad Privada del Valle | Gestión 2026**
Docente: Ing. Victor Ortega Lijeron

Proyecto construido en clase junto con los alumnos.  
Aplica los temas de **Clase 4** (Layout y Vistas Parciales) y **Clase 5** (Páginas de Contenido, OnPost, BindProperty, TempData, ModelState).

---

## Estructura del proyecto

```
PortalEstudiantil/
├── Program.cs
├── PortalEstudiantil.csproj
├── Models/
│   ├── Materia.cs          ← modelo + repositorio en memoria
│   └── ContactoForm.cs     ← modelo de formulario con DataAnnotations
├── Pages/
│   ├── _ViewImports.cshtml ← @using y @addTagHelper globales
│   ├── _ViewStart.cshtml   ← Layout por defecto para todas las páginas
│   ├── Index.cshtml / .cs  ← Página principal
│   ├── Contacto.cshtml / .cs ← Formulario con OnPost + validación
│   ├── Materias/
│   │   ├── Index.cshtml / .cs   ← Catálogo con filtro (BindProperty SupportsGet)
│   │   └── Detalle.cshtml / .cs ← Detalle con parámetro de ruta {id:int}
│   └── Shared/
│       ├── _Layout.cshtml         ← Plantilla maestra
│       ├── _NavBar.cshtml         ← Parcial: barra de navegación
│       ├── _Footer.cshtml         ← Parcial: pie de página
│       └── _TarjetaMateria.cshtml ← Parcial con modelo tipado
└── wwwroot/
    └── css/site.css
```

---

## Paso a paso — Implementación en clase

### PARTE 1 — Clase 4: Layout y Vistas Parciales

#### Paso 1: Crear el proyecto

1. Abrir Visual Studio 2026.
2. **File → New → Project** → buscar `ASP.NET Core Web App` (no el MVC).
3. Configurar:
   - **Project name:** `PortalEstudiantil`
   - **Framework:** .NET 10.0
   - **Authentication:** None
   - Marcar **Configure for HTTPS**
4. Hacer clic en **Create**.
5. Verificar que el proyecto compila con **Ctrl+F5**.

---

#### Paso 2: Crear `_ViewImports.cshtml`

> Este archivo habilita los Tag Helpers y los `@using` globales para todas las páginas.

En la carpeta `Pages/`, el archivo ya existe. Reemplazar su contenido:

```cshtml
@using PortalEstudiantil
@using PortalEstudiantil.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

**¿Por qué importa?**  
Sin `@addTagHelper`, los atributos `asp-page`, `asp-for`, `asp-route-*` no funcionan en ninguna vista.

---

#### Paso 3: Verificar `_ViewStart.cshtml`

El archivo en `Pages/_ViewStart.cshtml` define el layout por defecto. Debe quedar así:

```cshtml
@{
    Layout = "_Layout";
}
```

Esto evita escribir `Layout = "_Layout"` en cada página. Cualquier página puede sobreescribirlo con `Layout = null` si necesita un diseño diferente.

---

#### Paso 4: Crear `_Layout.cshtml`

En `Pages/Shared/_Layout.cshtml`, construir la plantilla maestra:

```cshtml
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <title>@ViewData["Title"] — Portal Estudiantil</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" />
    @await RenderSectionAsync("Estilos", required: false)
</head>
<body>
    <partial name="_NavBar" />

    <main>
        @RenderBody()
    </main>

    <partial name="_Footer" />

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

**Puntos clave a explicar:**
- `@RenderBody()` — obligatorio, único, aquí va el contenido de cada página.
- `@await RenderSectionAsync("Scripts", required: false)` — las páginas pueden inyectar JS propio.
- `<partial name="_NavBar" />` — incluye la vista parcial de navegación.
- `@ViewData["Title"]` — cada página define su propio título.

---

#### Paso 5: Crear `_NavBar.cshtml` (Vista Parcial)

Crear el archivo `Pages/Shared/_NavBar.cshtml`. No lleva `@page` (no es una página enrutable).

```cshtml
<nav class="navbar navbar-expand-lg navbar-dark" style="background-color: #1B3A6B;">
    <div class="container">
        <a class="navbar-brand fw-bold" asp-page="/Index">🎓 Portal Estudiantil</a>
        <button class="navbar-toggler" type="button"
                data-bs-toggle="collapse" data-bs-target="#navPrincipal">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navPrincipal">
            <ul class="navbar-nav me-auto">
                <li class="nav-item"><a class="nav-link" asp-page="/Index">Inicio</a></li>
                <li class="nav-item"><a class="nav-link" asp-page="/Materias/Index">Materias</a></li>
                <li class="nav-item"><a class="nav-link" asp-page="/Contacto">Contacto</a></li>
            </ul>
        </div>
    </div>
</nav>
```

**Puntos clave:**
- Empieza con `_` por convención (indica que es parcial).
- Sin `@page` → no genera URL propia.
- `asp-page="/Index"` genera la URL correcta con Tag Helpers.

---

#### Paso 6: Crear `_Footer.cshtml` (Vista Parcial)

Crear `Pages/Shared/_Footer.cshtml`:

```cshtml
<footer class="bg-dark text-white mt-5 py-4">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <h6 class="fw-bold">🎓 Portal Estudiantil</h6>
                <p class="text-white-50 small mb-0">Universidad Privada del Valle</p>
            </div>
            <div class="col-md-6 text-md-end">
                <p class="text-white-50 small mb-0">Programación Web III — 2026</p>
                <p class="text-white-50 small mb-0">Ing. Victor Ortega Lijeron</p>
            </div>
        </div>
    </div>
</footer>
```

---

#### Paso 7: Crear el modelo `Materia.cs`

Crear la carpeta `Models/` y dentro el archivo `Materia.cs`:

```csharp
namespace PortalEstudiantil.Models;

public class Materia
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Docente { get; set; } = string.Empty;
    public int HorasSemanales { get; set; }
    public string Semestre { get; set; } = string.Empty;
    public string Icono { get; set; } = "📚";
    public bool Activa { get; set; } = true;
}

public static class MateriasRepo
{
    public static List<Materia> Lista =>
    [
        new() { Id = 1, Nombre = "Programación Web I",   /* ... */ },
        new() { Id = 2, Nombre = "Programación Web II",  /* ... */ },
        new() { Id = 3, Nombre = "Programación Web III", /* ... */ },
        // agregar más...
    ];

    public static Materia? BuscarPorId(int id) =>
        Lista.FirstOrDefault(m => m.Id == id);

    public static List<string> Semestres() =>
        Lista.Select(m => m.Semestre).Distinct().Order().ToList();
}
```

---

#### Paso 8: Crear `_TarjetaMateria.cshtml` (Parcial con modelo tipado)

Crear `Pages/Shared/_TarjetaMateria.cshtml`:

```cshtml
@model PortalEstudiantil.Models.Materia

<div class="card h-100 shadow-sm">
    <div class="card-body">
        <span class="fs-2">@Model.Icono</span>
        <h6 class="card-title fw-bold mt-2">@Model.Nombre</h6>
        <p class="card-text text-muted small">@Model.Descripcion</p>
        <p class="small"><span class="text-muted">Docente:</span> @Model.Docente</p>
    </div>
    <div class="card-footer bg-transparent">
        <a asp-page="/Materias/Detalle"
           asp-route-id="@Model.Id"
           class="btn btn-sm btn-outline-primary w-100">Ver detalle →</a>
    </div>
</div>
```

**Punto clave:** `@model` en una parcial define su modelo tipado. Se incluye con:
```cshtml
<partial name="_TarjetaMateria" model="@unaMateria" />
```

---

#### Paso 9: Crear `Pages/Index.cshtml` y `Index.cshtml.cs`

**Index.cshtml.cs:**
```csharp
public class IndexModel : PageModel
{
    public int TotalMaterias { get; private set; }
    public List<Materia> MateriasDestacadas { get; private set; } = [];

    public void OnGet()
    {
        TotalMaterias      = MateriasRepo.Lista.Count;
        MateriasDestacadas = MateriasRepo.Lista.Where(m => m.Activa).Take(3).ToList();
    }
}
```

**Index.cshtml** (fragmento clave — usar la parcial en un foreach):
```cshtml
@foreach (var materia in Model.MateriasDestacadas)
{
    <div class="col-md-4">
        <partial name="_TarjetaMateria" model="@materia" />
    </div>
}
```

---

#### Paso 10: Crear `Pages/Materias/Index.cshtml` con filtro

**Concepto nuevo:** `[BindProperty(SupportsGet = true)]` permite recibir parámetros de query string en GET.

```csharp
public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? SemestreFiltro { get; set; }

    public List<Materia> Materias { get; private set; } = [];

    public void OnGet()
    {
        Materias = string.IsNullOrEmpty(SemestreFiltro)
            ? MateriasRepo.Lista
            : MateriasRepo.Lista.Where(m => m.Semestre == SemestreFiltro).ToList();
    }
}
```

URL resultante con filtro: `/Materias?semestre=3°`

---

#### Paso 11: Crear `Pages/Materias/Detalle.cshtml` con parámetro de ruta

La directiva `@page "{id:int}"` hace que la URL sea `/Materias/Detalle/3`.

```cshtml
@page "{id:int}"
@model PortalEstudiantil.Pages.Materias.DetalleModel
```

```csharp
public IActionResult OnGet(int id)
{
    var materia = MateriasRepo.BuscarPorId(id);
    if (materia is null)
        return NotFound();   // devuelve HTTP 404

    Materia = materia;
    return Page();
}
```

---

### PARTE 2 — Clase 5: Formulario de Contacto con OnPost

#### Paso 12: Crear el modelo `ContactoForm.cs` con DataAnnotations

```csharp
using System.ComponentModel.DataAnnotations;

public class ContactoForm
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [Display(Name = "Nombre completo")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "Ingrese un email válido.")]
    [Display(Name = "Correo electrónico")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "El asunto es obligatorio.")]
    [Display(Name = "Asunto")]
    public string Asunto { get; set; } = string.Empty;

    [Required(ErrorMessage = "El mensaje es obligatorio.")]
    [StringLength(1000, MinimumLength = 10)]
    [Display(Name = "Mensaje")]
    public string Mensaje { get; set; } = string.Empty;
}
```

---

#### Paso 13: Crear `Contacto.cshtml.cs` con OnPost

```csharp
public class ContactoModel : PageModel
{
    // [BindProperty] vincula los campos del formulario POST con esta propiedad.
    [BindProperty]
    public ContactoForm Formulario { get; set; } = new();

    public static List<ContactoForm> MensajesEnviados { get; } = [];

    public void OnGet() { }

    public IActionResult OnPost()
    {
        // Verifica [Required], [EmailAddress], etc.
        if (!ModelState.IsValid)
            return Page();  // re-muestra el form con errores

        MensajesEnviados.Add(Formulario);

        // TempData persiste solo hasta la próxima petición (tras la redirección)
        TempData["MensajeOk"] = $"Gracias, {Formulario.Nombre}. Tu mensaje fue recibido.";

        // Patrón POST-Redirect-GET: evita doble envío al refrescar
        return RedirectToPage();
    }
}
```

---

#### Paso 14: Crear `Contacto.cshtml` con Tag Helpers de formulario

```cshtml
@page
@model PortalEstudiantil.Pages.ContactoModel

@* Mostrar mensaje de éxito tras la redirección *@
@if (TempData["MensajeOk"] != null)
{
    <div class="alert alert-success">✅ @TempData["MensajeOk"]</div>
}

<form method="post">
    <div class="mb-3">
        <label asp-for="Formulario.Nombre" class="form-label"></label>
        <input asp-for="Formulario.Nombre" class="form-control" />
        <span asp-validation-for="Formulario.Nombre" class="text-danger small"></span>
    </div>
    <div class="mb-3">
        <label asp-for="Formulario.Email" class="form-label"></label>
        <input asp-for="Formulario.Email" class="form-control" />
        <span asp-validation-for="Formulario.Email" class="text-danger small"></span>
    </div>
    <div class="mb-3">
        <label asp-for="Formulario.Asunto" class="form-label"></label>
        <input asp-for="Formulario.Asunto" class="form-control" />
        <span asp-validation-for="Formulario.Asunto" class="text-danger small"></span>
    </div>
    <div class="mb-4">
        <label asp-for="Formulario.Mensaje" class="form-label"></label>
        <textarea asp-for="Formulario.Mensaje" class="form-control" rows="4"></textarea>
        <span asp-validation-for="Formulario.Mensaje" class="text-danger small"></span>
    </div>
    <button type="submit" class="btn btn-primary w-100">Enviar mensaje</button>
</form>
```

**Tag Helpers de formulario:**
- `asp-for="Formulario.Nombre"` → genera `name`, `id` y `value` correctos para el binding.
- `asp-validation-for="Formulario.Nombre"` → muestra el error de ModelState si la validación falla.
- `asp-label-for` con `[Display(Name="...")]` → muestra el nombre amigable del campo.

---

#### Paso 15: Agregar validación cliente (jQuery Unobtrusive)

En la sección Scripts de `Contacto.cshtml`:

```cshtml
@section Scripts {
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.20.0/jquery.validate.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/4.0.0/jquery.validate.unobtrusive.min.js"></script>
}
```

Esto activa la validación en el navegador antes de hacer la petición al servidor.

---

#### Paso 16: Probar el flujo completo

1. Ejecutar con `Ctrl+F5`.
2. Ir a `/Contacto`.
3. Enviar el formulario **vacío** → verificar mensajes de error (validación servidor y cliente).
4. Llenar correctamente y enviar → verificar que aparece el mensaje de éxito.
5. Refrescar la página → verificar que NO se reenvía el formulario (patrón PRG).
6. Ir a `/Materias` y probar el filtro por semestre.
7. Hacer clic en "Ver detalle" de una materia → verificar URL `/Materias/Detalle/1`.

---

## Conceptos aplicados

| Concepto | Dónde se aplica |
|---|---|
| `_Layout.cshtml` + `@RenderBody()` | `Pages/Shared/_Layout.cshtml` |
| `@RenderSection("Scripts", false)` | Layout → `Contacto.cshtml` usa `@section Scripts` |
| `_ViewStart.cshtml` | Layout por defecto para todas las páginas |
| `_ViewImports.cshtml` | `@addTagHelper` y `@using` globales |
| Vista Parcial sin modelo | `_NavBar.cshtml`, `_Footer.cshtml` |
| Vista Parcial con modelo tipado | `_TarjetaMateria.cshtml` → `<partial model="@item">` |
| `OnGet()` con datos | `Index`, `Materias/Index`, `Materias/Detalle` |
| `[BindProperty(SupportsGet=true)]` | Filtro por semestre en `Materias/Index` |
| `@page "{id:int}"` + `NotFound()` | `Materias/Detalle` |
| `[BindProperty]` en POST | `Contacto` — binding del formulario |
| `ModelState.IsValid` | `Contacto.OnPost()` |
| `DataAnnotations` | `ContactoForm.cs` — `[Required]`, `[EmailAddress]` |
| `asp-for` / `asp-validation-for` | Formulario de contacto |
| `TempData` + Patrón PRG | `Contacto.OnPost()` → `RedirectToPage()` |
