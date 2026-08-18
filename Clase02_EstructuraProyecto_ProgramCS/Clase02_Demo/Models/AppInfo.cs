// ╔══════════════════════════════════════════════════════════════════════════╗
// ║  PROGRAMACIÓN WEB III — Clase 2                                         ║
// ║  Tema 1.2.3: Patrón Options — Mapear configuración a clases C#          ║
// ╚══════════════════════════════════════════════════════════════════════════╝

namespace Clase02_Demo.Models;

// ▶ MOSTRAR: El Patrón Options (IOptions<T>)
//   En lugar de acceder a builder.Configuration["AppInfo:Nombre"] (string sin tipo),
//   podemos MAPEAR toda una sección JSON a una clase C# tipada.
//
//   Ventajas del Patrón Options:
//   - IntelliSense en el IDE al acceder las propiedades
//   - Verificación de tipos en tiempo de compilación
//   - Validación automática con Data Annotations
//   - Inyectable en constructores

/// <summary>
/// Modelo de configuración de la aplicación.
/// Mapeado desde la sección "AppInfo" de appsettings.json.
///
/// ▶ REGISTRO EN Program.cs:
/// builder.Services.Configure&lt;AppInfo&gt;(builder.Configuration.GetSection("AppInfo"));
///
/// ▶ USO EN PageModel:
/// public class IndexModel : PageModel {
///     private readonly AppInfo _appInfo;
///     public IndexModel(IOptions&lt;AppInfo&gt; options) { _appInfo = options.Value; }
/// }
/// </summary>
public class AppInfo
{
    // ▶ Las propiedades deben tener el MISMO nombre que las claves del JSON
    //   (por convención, case-insensitive en ASP.NET Core)

    /// <summary>Nombre de la aplicación</summary>
    public string Nombre { get; set; } = string.Empty;

    /// <summary>Versión actual</summary>
    public string Version { get; set; } = string.Empty;

    /// <summary>Autor o docente responsable</summary>
    public string Autor { get; set; } = string.Empty;

    /// <summary>Institución educativa</summary>
    public string Institucion { get; set; } = string.Empty;

    /// <summary>Gestión académica</summary>
    public string Gestion { get; set; } = string.Empty;

    /// <summary>Descripción del proyecto</summary>
    public string Descripcion { get; set; } = string.Empty;
}

// ▶ MOSTRAR: Feature Flags — patrón para activar/desactivar funcionalidades
/// <summary>
/// Flags de características. Mapeado desde "Features" en appsettings.json.
/// Permite activar/desactivar features sin recompilar la aplicación.
/// </summary>
public class FeatureFlags
{
    public bool MostrarInformacionDebug { get; set; }
    public bool MostrarConfiguracion { get; set; }
    public bool MostrarPipelineMiddleware { get; set; }
}
