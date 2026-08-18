// ╔══════════════════════════════════════════════════════════════════════════╗
// ║  PROGRAMACIÓN WEB III — Clase 2                                         ║
// ║  Tema 1.2.2: Inyección de Dependencias — Servicios personalizados       ║
// ╚══════════════════════════════════════════════════════════════════════════╝

namespace Clase02_Demo.Services;

// ▶ MOSTRAR: Patrón Interface + Implementación para Dependency Injection
//
//   RAZÓN: ¿Por qué usar una interfaz?
//   - Desacoplamiento: El PageModel depende de IAppInfoService (abstracción),
//     no de AppInfoService (implementación concreta).
//   - Testabilidad: En unit tests se puede inyectar un "mock" de la interfaz.
//   - Intercambiabilidad: Si mañana cambias la implementación (ej: leer de BD
//     en lugar de appsettings), el código que consume la interfaz NO cambia.

/// <summary>
/// Contrato del servicio de información de la aplicación.
/// ▶ MOSTRAR: Interfaz = "qué hace" sin decir "cómo lo hace".
/// </summary>
public interface IAppInfoService
{
    /// <summary>Retorna el nombre completo de la aplicación con versión</summary>
    string ObtenerNombreCompleto();

    /// <summary>Retorna el entorno de ejecución actual</summary>
    string ObtenerEntorno();

    /// <summary>Retorna información del servidor y request actual</summary>
    InformacionServidor ObtenerInfoServidor();
}

/// <summary>
/// DTO para información del servidor.
/// ▶ MOSTRAR: DTO = Data Transfer Object — clase simple para transportar datos.
/// </summary>
public class InformacionServidor
{
    public string NombreMaquina { get; set; } = string.Empty;
    public string SistemaOperativo { get; set; } = string.Empty;
    public string VersionDotNet { get; set; } = string.Empty;
    public DateTime HoraServidor { get; set; }
    public string Entorno { get; set; } = string.Empty;
}

/// <summary>
/// Implementación concreta del servicio.
/// ▶ MOSTRAR: Implementación = "cómo lo hace".
///   Inyectamos IWebHostEnvironment (servicio de ASP.NET Core que da info del entorno).
/// </summary>
public class AppInfoService : IAppInfoService
{
    // ▶ MOSTRAR: Inyección de dependencias en el constructor.
    //   ASP.NET Core resuelve automáticamente IWebHostEnvironment porque
    //   está registrado internamente por el framework.
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _config;

    /// <summary>
    /// Constructor con inyección de dependencias.
    /// ▶ MOSTRAR: Los parámetros son resueltos automáticamente por el DI container.
    /// </summary>
    public AppInfoService(IWebHostEnvironment env, IConfiguration config)
    {
        _env = env;
        _config = config;
    }

    // ▶ MOSTRAR: Implementación del método de la interfaz
    public string ObtenerNombreCompleto()
    {
        var nombre = _config["AppInfo:Nombre"] ?? "App sin nombre";
        var version = _config["AppInfo:Version"] ?? "0.0.0";
        return $"{nombre} v{version}";
    }

    public string ObtenerEntorno()
    {
        // ▶ MOSTRAR: IWebHostEnvironment da acceso al entorno actual.
        //   .EnvironmentName retorna "Development", "Staging" o "Production".
        return _env.EnvironmentName;
    }

    public InformacionServidor ObtenerInfoServidor()
    {
        return new InformacionServidor
        {
            // ▶ MOSTRAR: Environment.MachineName viene del sistema operativo
            NombreMaquina = System.Environment.MachineName,

            // ▶ MOSTRAR: RuntimeInformation para info de la plataforma
            SistemaOperativo = System.Runtime.InteropServices.RuntimeInformation.OSDescription,

            // ▶ MOSTRAR: Environment.Version da la versión del .NET Runtime
            VersionDotNet = System.Environment.Version.ToString(),

            HoraServidor = DateTime.Now,
            Entorno = _env.EnvironmentName
        };
    }
}
