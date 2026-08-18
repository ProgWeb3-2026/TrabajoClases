// ╔══════════════════════════════════════════════════════════════════════════╗
// ║  PROGRAMACIÓN WEB III — Clase 2                                         ║
// ║  Tema 1.2: Index.cshtml.cs — PageModel de la página principal           ║
// ╚══════════════════════════════════════════════════════════════════════════╝

using Clase02_Demo.Models;
using Clase02_Demo.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Clase02_Demo.Pages;

// ▶ MOSTRAR: Un PageModel es la clase "code-behind" de una página Razor.
//   Contiene la lógica de la página: qué datos obtener, qué hacer en POST.
//   La clase DEBE heredar de PageModel.
//
//   CONVENCIÓN: Index.cshtml → Index.cshtml.cs → clase IndexModel
//               Si.cshtml se llama "Configuracion.cshtml" → clase ConfiguracionModel

/// <summary>
/// PageModel de la página principal.
/// Demuestra el sistema de configuración y la inyección de dependencias.
/// </summary>
public class IndexModel : PageModel
{
    // ─────────────────────────────────────────────────────────────────────────
    // ▶ PUNTO 1: INYECCIÓN DE DEPENDENCIAS EN EL CONSTRUCTOR
    //   Los campos privados (_logger, _appInfo, etc.) se marcan con readonly
    //   porque solo se asignan en el constructor y no cambian después.
    // ─────────────────────────────────────────────────────────────────────────

    // ▶ MOSTRAR: ILogger<T> — servicio de logging integrado en ASP.NET Core.
    //   Permite escribir mensajes de log categorizados.
    private readonly ILogger<IndexModel> _logger;

    // ▶ MOSTRAR: IOptions<AppInfo> — patrón Options para leer configuración tipada.
    //   Se accede con .Value para obtener el objeto AppInfo.
    private readonly IOptions<AppInfo> _appInfoOptions;

    // ▶ MOSTRAR: IOptions<FeatureFlags> — feature flags desde appsettings.json
    private readonly IOptions<FeatureFlags> _features;

    // ▶ MOSTRAR: Nuestro servicio personalizado inyectado como interfaz.
    private readonly IAppInfoService _appInfoService;

    // ▶ MOSTRAR: IConfiguration — acceso directo al sistema de configuración.
    //   Alternativa a IOptions para casos simples.
    private readonly IConfiguration _config;

    // ▶ MOSTRAR: IWebHostEnvironment — información del entorno de ejecución.
    private readonly IWebHostEnvironment _env;

    /// <summary>
    /// Constructor — ASP.NET Core resuelve e inyecta automáticamente
    /// todos los parámetros desde el DI container.
    ///
    /// ▶ MOSTRAR: El DI container sabe cómo crear cada dependencia porque
    ///   las registramos en Program.cs con builder.Services.*
    /// </summary>
    public IndexModel(
        ILogger<IndexModel> logger,
        IOptions<AppInfo> appInfoOptions,
        IOptions<FeatureFlags> features,
        IAppInfoService appInfoService,
        IConfiguration config,
        IWebHostEnvironment env)
    {
        _logger = logger;
        _appInfoOptions = appInfoOptions;
        _features = features;
        _appInfoService = appInfoService;
        _config = config;
        _env = env;
    }

    // ─────────────────────────────────────────────────────────────────────────
    // ▶ PUNTO 2: PROPIEDADES DEL PageModel
    //   Estas propiedades son accesibles desde la vista (.cshtml) con @Model.
    //   La vista SOLO lee estas propiedades — no tiene acceso a los servicios.
    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>Información de la app desde appsettings.json</summary>
    public AppInfo InfoApp { get; private set; } = new();

    /// <summary>Feature flags activos</summary>
    public FeatureFlags Features { get; private set; } = new();

    /// <summary>Información del servidor web</summary>
    public InformacionServidor InfoServidor { get; private set; } = new();

    /// <summary>Nombre completo desde el servicio inyectado</summary>
    public string NombreCompleto { get; private set; } = string.Empty;

    /// <summary>Variables de configuración para demo en la vista</summary>
    public Dictionary<string, string> ConfiguracionDemo { get; private set; } = new();

    // ─────────────────────────────────────────────────────────────────────────
    // ▶ PUNTO 3: HANDLER OnGet()
    //   Se ejecuta automáticamente cuando el navegador hace GET a esta página.
    //   Aquí se obtienen los datos que la vista va a mostrar.
    //
    //   Handlers disponibles:
    //   - OnGet()    → petición GET
    //   - OnPost()   → petición POST (formularios)
    //   - OnGetAsync() / OnPostAsync() → versiones asíncronas
    // ─────────────────────────────────────────────────────────────────────────
    public void OnGet()
    {
        // ▶ MOSTRAR: Logging — registrar actividad en el log del servidor.
        //   Se ve en la consola de VS (Output window) durante la ejecución.
        _logger.LogInformation("📄 Página Index cargada a las {Hora}", DateTime.Now.ToString("HH:mm:ss"));

        // ▶ MOSTRAR: Acceder a la configuración tipada con IOptions<T>.Value
        InfoApp = _appInfoOptions.Value;
        Features = _features.Value;

        // ▶ MOSTRAR: Usar el servicio inyectado
        NombreCompleto = _appInfoService.ObtenerNombreCompleto();
        InfoServidor = _appInfoService.ObtenerInfoServidor();

        // ▶ MOSTRAR: Acceso directo con IConfiguration["clave:subclave"]
        //   Útil para valores únicos. Para secciones completas, preferir IOptions<T>.
        ConfiguracionDemo = new Dictionary<string, string>
        {
            ["AppInfo:Nombre"]          = _config["AppInfo:Nombre"] ?? "-",
            ["AppInfo:Version"]         = _config["AppInfo:Version"] ?? "-",
            ["Logging:LogLevel:Default"] = _config["Logging:LogLevel:Default"] ?? "-",
            ["AllowedHosts"]            = _config["AllowedHosts"] ?? "-",
            ["ASPNETCORE_ENVIRONMENT"]  = _env.EnvironmentName,
        };

        // ▶ MOSTRAR: Logging con distintos niveles
        if (_env.IsDevelopment())
        {
            _logger.LogDebug("🔧 Modo desarrollo — mostrando información de debug");
        }
    }
}
