// ▶ MOSTRAR: 'using' implícitos habilitados en el .csproj con ImplicitUsings=enable.
//   No necesitamos escribir: using Microsoft.AspNetCore.Builder; etc.
using Clase02_Demo.Models;
using Clase02_Demo.Services;

// ─────────────────────────────────────────────────────────────────────────────
// ▶ PUNTO 2: WebApplication.CreateBuilder(args)
//   Crea el "constructor" de la aplicación web. Este objeto:
//   - Lee appsettings.json automáticamente
//   - Lee appsettings.{Entorno}.json (sobreescribe el anterior)
//   - Lee variables de entorno
//   - Lee los argumentos de línea de comandos (args)
//   - Configura el sistema de Logging
//   - Configura el servidor Kestrel
// ─────────────────────────────────────────────────────────────────────────────
var builder = WebApplication.CreateBuilder(args);

// ─────────────────────────────────────────────────────────────────────────────
// ▶ PUNTO 3: REGISTRO DE SERVICIOS (Dependency Injection Container)
//   builder.Services es el contenedor de Inyección de Dependencias (DI).
//   Aquí se "registran" todos los servicios que la aplicación va a usar.
//   Más adelante, estos servicios se "inyectan" donde se necesiten (en constructores).
//
//   PREGUNTA PARA ESTUDIANTES: ¿Qué es Inyección de Dependencias?
//   → Un patrón donde los objetos reciben sus dependencias en lugar de crearlas.
//   → Ventajas: testabilidad, desacoplamiento, intercambiabilidad.
// ─────────────────────────────────────────────────────────────────────────────

// ▶ MOSTRAR 3.1: AddRazorPages() registra todos los servicios de Razor Pages.
//   Sin esta línea, las páginas .cshtml NO funcionan.
builder.Services.AddRazorPages();

// ▶ MOSTRAR 3.2: Patrón Options — mapear secciones de configuración a clases C# tipadas.
//   builder.Configuration.GetSection("AppInfo") lee la sección "AppInfo" de appsettings.json.
//   Configure<AppInfo>() registra el mapeo en el DI container.
//   Luego en cualquier clase: inyectar IOptions<AppInfo> y acceder con .Value
builder.Services.Configure<AppInfo>(
    builder.Configuration.GetSection("AppInfo"));

builder.Services.Configure<FeatureFlags>(
    builder.Configuration.GetSection("Features"));

// ▶ MOSTRAR 3.3: Registrar servicio personalizado con su interfaz.
//   AddScoped    = nueva instancia por cada petición HTTP
//   AddSingleton = una instancia para toda la vida de la aplicación
//   AddTransient = nueva instancia cada vez que se solicita
builder.Services.AddScoped<IAppInfoService, AppInfoService>();

// ▶ MOSTRAR 3.4: Acceder a configuración en Program.cs para logging de inicio.
var appNombre = builder.Configuration["AppInfo:Nombre"] ?? "Sin nombre";
Console.WriteLine($"[Startup] Iniciando: {appNombre}");
Console.WriteLine($"[Startup] Entorno: {builder.Environment.EnvironmentName}");

// ─────────────────────────────────────────────────────────────────────────────
// ▶ PUNTO 4: builder.Build()
//   Construye la aplicación con todos los servicios registrados.
//   IMPORTANTE: Después de este punto, NO se pueden agregar más servicios.
//   La variable 'app' representa la aplicación web lista para configurar.
// ─────────────────────────────────────────────────────────────────────────────
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────────
// ▶ PUNTO 5: PIPELINE DE MIDDLEWARE
//   El pipeline es la CADENA de componentes que procesan cada petición HTTP.
//
//   ANALOGÍA: Como un filtro de agua — la petición (agua) pasa por múltiples
//   etapas (filtros) en orden antes de llegar al destino (tu página).
//
//   ⚠️  El ORDEN de los middleware importa — cada app.Use* está en el lugar correcto.
// ─────────────────────────────────────────────────────────────────────────────

// ▶ MIDDLEWARE 1: Manejo de errores según el entorno
//   app.Environment.IsDevelopment() lee ASPNETCORE_ENVIRONMENT
if (app.Environment.IsDevelopment())
{
    // En desarrollo: muestra stack trace completo (solo para el desarrollador)
    app.UseDeveloperExceptionPage();
    Console.WriteLine("[Startup] Modo DESARROLLO — errores detallados habilitados");
}
else
{
    // En producción: página de error amigable sin detalles del servidor
    app.UseExceptionHandler("/Error");
    // HSTS: indica al navegador que use HTTPS por 30 días
    app.UseHsts();
}

// ▶ MIDDLEWARE 2: Redirección HTTP → HTTPS
//   Peticiones por HTTP (puerto 80) se redirigen automáticamente a HTTPS
app.UseHttpsRedirection();

// ▶ MIDDLEWARE 3: Archivos estáticos
//   Sirve archivos de wwwroot/ directamente. Si la URL coincide con un archivo,
//   retorna ese archivo SIN pasar por los controllers/páginas.
//   Ejemplo: /css/site.css → wwwroot/css/site.css
app.UseStaticFiles();

// ▶ MIDDLEWARE 4: Routing
//   Analiza la URL y determina qué página/controller debe manejarla.
//   DEBE ir antes de UseAuthorization.
app.UseRouting();

// ▶ MIDDLEWARE 5: Autorización
//   Verifica permisos de acceso. DEBE ir después de UseRouting.
//   (La autenticación completa se verá en Unidades 2 y 3)
app.UseAuthorization();

// ─────────────────────────────────────────────────────────────────────────────
// ▶ PUNTO 6: ENDPOINTS — cómo se mapean las URLs a las páginas
// ─────────────────────────────────────────────────────────────────────────────

// ▶ MapRazorPages: conecta las URLs con páginas .cshtml bajo /Pages/
//   Convención:
//   Pages/Index.cshtml         → URL: /
//   Pages/Configuracion.cshtml → URL: /Configuracion
//   Pages/Demo/Lista.cshtml    → URL: /Demo/Lista
app.MapRazorPages();

// ─────────────────────────────────────────────────────────────────────────────
// ▶ PUNTO 7: app.Run() — arranca el servidor y comienza a escuchar peticiones.
//   Este método BLOQUEA el programa hasta que se detenga el servidor.
//   Kestrel escucha en: https://localhost:5001 / http://localhost:5000
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("[Startup] Servidor listo. Presionar Ctrl+C para detener.");
app.Run();

// ─────────────────────────────────────────────────────────────────────────────
// RESUMEN PARA PIZARRÓN:
//
//  CreateBuilder → Registrar servicios → Build → Pipeline middleware → Endpoints → Run
//
//  1. CreateBuilder(args)            → Host, configuración, logging
//  2. builder.Services.Add*()        → DI container: Razor Pages, Options, servicios propios
//  3. builder.Build()                → App construida, DI container listo
//  4. app.Use*() en orden correcto   → Pipeline de middleware
//  5. app.Map*()                     → Rutas: pages, controllers, minimal APIs
//  6. app.Run()                      → 🚀 Servidor iniciado
// ─────────────────────────────────────────────────────────────────────────────
