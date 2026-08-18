# Clase 2 — Estructura de Proyecto y Program.cs
## Programación Web III | Ing. Victor Ortega Lijeron

---

## 🎯 Objetivos de la Clase

- Analizar la estructura de archivos y carpetas de un proyecto ASP.NET Core
- Comprender el rol de `Program.cs` como punto de entrada
- Configurar el pipeline de middleware correctamente
- Manejar configuración con `appsettings.json` y el Patrón Options

---

## 📁 Estructura del Proyecto

```
Clase02_EstructuraProyecto_ProgramCS/
└── Clase02_Demo/
    ├── Clase02_Demo.csproj      ← Configuración MSBuild
    ├── Program.cs               ← ARCHIVO PRINCIPAL DE LA CLASE
    ├── appsettings.json         ← Configuración base
    ├── appsettings.Development.json ← Sobreescritura para dev
    ├── Models/
    │   └── AppInfo.cs           ← Patrón Options
    ├── Services/
    │   └── AppInfoService.cs    ← DI: Interface + Implementación
    ├── Pages/
    │   ├── Index.cshtml         ← Vista: muestra todo el contenido
    │   ├── Index.cshtml.cs      ← PageModel con DI inyectada
    │   ├── _ViewStart.cshtml    ← Layout por defecto
    │   ├── _ViewImports.cshtml  ← usings globales + TagHelpers
    │   └── Shared/
    │       └── _Layout.cshtml   ← Plantilla HTML compartida
    └── wwwroot/
        └── css/
            └── site.css         ← Estilos propios
```

---

## 🗺️ Guía de Demostración (orden sugerido)

### Parte 1 — El archivo .csproj (5 min)
1. Abrir `Clase02_Demo.csproj` en VS
2. Mostrar: `TargetFramework`, `Nullable`, `ImplicitUsings`
3. **Pregunta:** ¿Qué SDK se usa? → `Microsoft.NET.Sdk.Web`

### Parte 2 — Program.cs (20 min)
1. Abrir `Program.cs`
2. Seguir los comentarios ▶ en orden:
   - **PUNTO 1:** Top-level statements — comparar con el "before" comentado
   - **PUNTO 2:** `WebApplication.CreateBuilder(args)` — qué hace internamente
   - **PUNTO 3:** `builder.Services.*` — registrar servicios
     - `AddRazorPages()`
     - `Configure<AppInfo>()` — patrón Options
     - `AddScoped<IAppInfoService, AppInfoService>()`
   - **PUNTO 4:** `builder.Build()` — el DI container queda sellado
   - **PUNTO 5:** Pipeline de middleware — **mostrar el diagrama en pantalla**
   - **PUNTO 6:** `MapRazorPages()` — convención de rutas
   - **PUNTO 7:** `app.Run()` — bloqueante, arranca Kestrel

### Parte 3 — appsettings.json (10 min)
1. Mostrar la sección `AppInfo` personalizada
2. **DEMO EN VIVO:** Cambiar el valor de `AppInfo:Nombre` en appsettings.json,
   guardar el archivo, y refrescar la página. El valor cambia SIN recompilar.
3. Mostrar `appsettings.Development.json` y cómo sobreescribe valores

### Parte 4 — Ejecutar y explorar (15 min)
1. Ejecutar con F5 (modo Debug) o Ctrl+F5 (sin debug)
2. Mostrar la página principal con todas las secciones
3. Señalar cada sección y relacionarla con el código:
   - "AppInfo" → viene de `appsettings.json`
   - "InfoServidor" → viene de `AppInfoService`
   - "Configuración RAW" → viene de `IConfiguration["clave"]`
   - "Pipeline" → el diagrama del flujo de middleware
   - "Estructura del Proyecto" → árbol de archivos del proyecto

### Parte 5 — Preguntas de cierre (10 min)
- ¿Por qué el orden del middleware importa?
- ¿Qué diferencia hay entre `appsettings.json` y `appsettings.Development.json`?
- ¿Para qué sirve `_ViewStart.cshtml`?
- ¿Qué significa `AddScoped` vs `AddSingleton` vs `AddTransient`?

---

## 🔧 Cómo ejecutar

```bash
# Desde la carpeta del proyecto:
cd Clase02_Demo
dotnet run

# O en Visual Studio:
# Abrir Clase02_Demo.csproj → F5
```

**Requisitos:**
- .NET 10 SDK: https://dotnet.microsoft.com/download/dotnet/10.0
- Visual Studio 2026 o VS Code con extensión C#

---

## 📌 Archivos clave con comentarios docentes

| Archivo | Temas cubiertos |
|---------|----------------|
| `Program.cs` | Top-level statements, builder, servicios, pipeline, Run |
| `appsettings.json` | Secciones, Connection Strings, Feature Flags |
| `Models/AppInfo.cs` | Patrón Options, IOptions<T> |
| `Services/AppInfoService.cs` | Interface + implementación, inyección de dependencias |
| `Pages/Index.cshtml.cs` | PageModel, OnGet(), propiedades, IConfiguration |
| `Pages/Index.cshtml` | @page, @model, @if, @foreach, @section, Tag Helpers |
| `Pages/Shared/_Layout.cshtml` | @RenderBody(), @RenderSection(), ViewData["Title"] |
| `Pages/_ViewStart.cshtml` | Layout por defecto |
| `Pages/_ViewImports.cshtml` | @using global, @addTagHelper |

---

*Programación Web III — Gestión 2026 | Universidad Privada del Valle*
