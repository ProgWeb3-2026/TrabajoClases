// Clase 3 — Razor Pages: Introducción
// Tema 1.3: ¿Qué son Razor Pages?, Sintaxis Razor, Routing

var builder = WebApplication.CreateBuilder(args);

// Razor Pages requiere este registro.
// Sin él, ninguna página .cshtml será accesible.
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// MapRazorPages conecta las URLs a las páginas bajo /Pages/ por convención:
//   Pages/Index.cshtml                → /
//   Pages/Productos/Index.cshtml      → /Productos
//   Pages/Productos/Detalle.cshtml    → /Productos/Detalle
//   Pages/Rutas/ConParametro.cshtml   → /Rutas/ConParametro
app.MapRazorPages();

app.Run();
