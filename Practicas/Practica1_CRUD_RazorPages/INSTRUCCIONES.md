# Práctica 1 — CRUD con Razor Pages
**Programación Web III | Universidad Privada del Valle | Gestión 2026**

---

## Objetivo

Implementar manualmente las páginas **Listar, Crear, Editar, Detalle y Eliminar** para el modelo que te fue asignado, aplicando lo visto en clases sobre Razor Pages, formularios, binding y validación.

---

## Modelo asignado

Cada estudiante trabaja sobre un único modelo. El proyecto base ya incluye los 5 modelos y sus servicios compilados. Trabaja únicamente sobre el tuyo.

| Modelo | Módulo | Carpeta a crear |
|---|---|---|
| `Pelicula` | Gestión de Películas | `Pages/Peliculas/` |
| `Evento` | Gestión de Eventos | `Pages/Eventos/` |
| `Vehiculo` | Gestión de Vehículos | `Pages/Vehiculos/` |
| `Hotel` | Gestión de Hoteles | `Pages/Hoteles/` |
| `Libro` | Gestión de Libros | `Pages/Libros/` |

---

## Propiedades de cada modelo

### Pelicula
`Id` (int) · `Titulo` (string) · `Director` (string) · `Genero` (string) · `Anio` (int) · `DuracionMinutos` (int)

### Evento
`Id` (int) · `Nombre` (string) · `Fecha` (DateTime) · `Lugar` (string) · `Capacidad` (int) · `TipoEvento` (string)

### Vehiculo
`Id` (int) · `Marca` (string) · `Modelo` (string) · `Anio` (int) · `Color` (string) · `Kilometraje` (int)

### Hotel
`Id` (int) · `Nombre` (string) · `Ciudad` (string) · `CategoriaEstrellas` (int) · `PrecioPorNoche` (decimal) · `Disponible` (bool)

### Libro
`Id` (int) · `Titulo` (string) · `Autor` (string) · `ISBN` (string) · `NumeroPaginas` (int) · `Genero` (string)

---

## Servicio disponible

El proyecto base ya incluye un servicio por cada modelo (por ejemplo `PeliculaService`). El servicio ya está registrado en `Program.cs` y listo para usar. Solo necesitas inyectarlo en el constructor de tus PageModels.

Los métodos disponibles son: `GetAll()`, `GetById(int id)`, `Create(modelo)`, `Update(modelo)`, `Delete(int id)`.

Revisa el código del servicio en la carpeta `Services/` para entender qué devuelve cada método.

---

## Pasos de implementación

### PASO 0 — Preparar tu rama de trabajo

Debes clonar el repositorio desde tu github

https://github.com/ProgWeb3-2026/Practica2Base.git
 
Abre la solución `PracticaBase.sln` en Visual Studio y verifica que compila correctamente con **Ctrl+F5**.

Cambia de Rama/Branch debes usar la rama con tu Nombre para trabajar.

---

### PASO 1 — Agregar validadores al modelo

Abre el archivo de tu modelo en la carpeta `Models/`. El modelo no tiene validadores — es tu tarea agregarlos.

Usa las anotaciones de `System.ComponentModel.DataAnnotations`. Aplica al menos **4 propiedades** con validadores apropiados según el tipo:

- Campos de texto obligatorios → `[Required]` y `[StringLength]`
- Campos numéricos con límites → `[Range]`
- Campos decimales positivos → `[Range]`
- Fechas → `[Required]`
- Usa `[Display(Name = "...")]` para mostrar etiquetas en español en los formularios

RECORDAR QUE LOS CAMPOS QUE VAMOS A DEJAR COMO NO REQUERIDOS DEBEN TENER EL "?" EN EL TIPO DE DATO PARA QUE PERMITA VALORES NULOS/VACIO ej:  int?

Consulta los modelos de los proyectos de clase para ver ejemplos de cómo se usan estas anotaciones.

---

### PASO 2 — Crear la carpeta del módulo

Dentro de `Pages/`, crea la carpeta correspondiente a tu modelo (ver tabla de arriba).

Todos tus archivos `.cshtml` y `.cshtml.cs` van dentro de esa carpeta.

---

### PASO 3 — Página Listar (`Index.cshtml`)

Esta página muestra todos los registros del servicio en una tabla HTML.

**PageModel (`Index.cshtml.cs`):**
- Inyectar el servicio en el constructor
- Declarar una propiedad pública de tipo `List<TuModelo>` para exponer los datos a la vista
- En `OnGet()`, llamar a `GetAll()` del servicio y asignar el resultado a esa propiedad

**Vista (`Index.cshtml`):**
- Directiva `@page` como primera línea (sin parámetros de ruta)
- Encabezado con el nombre del módulo y un botón/enlace para ir a Crear
- Mostrar `TempData["Mensaje"]` si existe (para mensajes de éxito después de guardar o eliminar)
- Tabla con una columna por cada propiedad del modelo (excluir `Id` si prefieres)
- Última columna de Acciones con enlaces a Detalle, Editar y Eliminar para cada fila
- Usar `asp-page` y `asp-route-id` en los enlaces de acción
- Si la lista está vacía, mostrar un mensaje indicándolo

---

### PASO 4 — Página Crear (`Crear.cshtml`)

Muestra un formulario vacío (GET) y lo procesa al enviarse (POST).

**PageModel (`Crear.cshtml.cs`):**
- Inyectar el servicio en el constructor
- Declarar una propiedad con `[BindProperty]` de tipo `TuModelo` — esto vincula los campos del formulario automáticamente
- `OnGet()` no necesita hacer nada (el formulario llega vacío)
- `OnPost()` debe:
  - Verificar `ModelState.IsValid` — si no es válido, retornar `Page()` para volver al formulario con los errores
  - Si es válido, llamar a `Create()` del servicio
  - Guardar un mensaje en `TempData["Mensaje"]`
  - Redirigir a la página Index con `RedirectToPage("Index")` (patrón PRG)

**Vista (`Crear.cshtml`):**
- Formulario con `method="post"` para cada propiedad del modelo (no incluir `Id`, lo asigna el servicio)
- Usar `asp-for` en los `<label>` e `<input>` para vincular con la propiedad `[BindProperty]`
- Usar `asp-validation-for` para mostrar los mensajes de error de validación debajo de cada campo
- Botón de envío y enlace para cancelar y volver al Index
- Agregar la sección `@section Scripts` con los scripts de validación del lado del cliente (jQuery Validate — ver la clase 5 de referencia)

---

### PASO 5 — Página Detalle (`Detalle.cshtml`)

Muestra todos los campos de un registro en modo solo lectura.

**PageModel (`Detalle.cshtml.cs`):**
- Inyectar el servicio en el constructor
- Declarar una propiedad pública de tipo `TuModelo` para la vista
- `OnGet(int id)` recibe el id por ruta, llama a `GetById(id)` y:
  - Si el resultado es `null`, retornar `NotFound()`
  - Si existe, asignarlo a la propiedad y retornar `Page()`

**Vista (`Detalle.cshtml`):**
- `@page "{id:int}"` como primera línea — el `id` viene de la URL
- Mostrar cada propiedad del modelo con una etiqueta descriptiva (puedes usar `<dl>`, `<table>`, tarjetas, etc.)
- Enlace para ir a Editar el mismo registro
- Enlace para volver al Index

---

### PASO 6 — Página Editar (`Editar.cshtml`)

Carga los datos del registro (GET) y guarda los cambios (POST).

**PageModel (`Editar.cshtml.cs`):**
- Inyectar el servicio en el constructor
- Declarar una propiedad con `[BindProperty]` de tipo `TuModelo`
- `OnGet(int id)`:
  - Llamar a `GetById(id)` — si es `null`, retornar `NotFound()`
  - Asignar el resultado al `[BindProperty]` para pre-poblar el formulario
- `OnPost()`:
  - Verificar `ModelState.IsValid`
  - Si es válido, llamar a `Update()` del servicio
  - Guardar mensaje en `TempData["Mensaje"]`
  - Redirigir a Index

**Vista (`Editar.cshtml`):**
- `@page "{id:int}"` como primera línea
- El formulario es casi idéntico al de Crear, con dos diferencias importantes:
  - Incluir un campo `<input type="hidden">` con `asp-for` apuntando al `Id` — sin esto el POST no sabrá qué registro actualizar
  - El título dice "Editar" en lugar de "Nuevo/Crear"
- Misma sección `@section Scripts` de validación

---

### PASO 7 —  PUNTOS EXTRA Página Eliminar (`Eliminar.cshtml`)

Muestra una confirmación antes de eliminar para evitar eliminaciones accidentales.

**PageModel (`Eliminar.cshtml.cs`):**
- Inyectar el servicio en el constructor
- Declarar una propiedad pública de tipo `TuModelo` para mostrar en la confirmación
- `OnGet(int id)`: cargar el registro con `GetById(id)` — si es `null`, retornar `NotFound()`
- `OnPost(int id)`: llamar a `Delete(id)`, guardar mensaje en `TempData["Mensaje"]` y redirigir a Index

**Vista (`Eliminar.cshtml`):**
- `@page "{id:int}"` como primera línea
- Mostrar los datos principales del registro (no todos los campos, solo los identificadores clave)
- Un mensaje de advertencia indicando que la acción no se puede deshacer
- Un formulario con `method="post"` que contiene únicamente el botón de confirmación
- Un enlace separado para cancelar y volver al Index sin eliminar

---

### PASO 8 — Agregar enlace al navbar

Edita `Pages/Shared/_Layout.cshtml` y agrega un enlace a tu módulo dentro del `<ul>` de navegación.

Usa `asp-page` apuntando a `/TuCarpeta/Index`.

---

### PASO 9 — Verificar el CRUD completo

Ejecuta con **Ctrl+F5** y prueba cada operación:

- [ ] La tabla de Listar muestra los registros de ejemplo del servicio
- [ ] El botón "Nuevo" lleva al formulario vacío de Crear
- [ ] Enviar el formulario de Crear **vacío** muestra los errores de validación
- [ ] Llenar y enviar Crear agrega el registro a la tabla
- [ ] "Ver" muestra el Detalle con todos los campos
- [ ] "Editar" llega con los campos pre-poblados
- [ ] Guardar en Editar actualiza el registro en la tabla
- [ ] "Eliminar" muestra la confirmación con datos del registro
- [ ] Confirmar Eliminar quita el registro de la tabla

---

### PASO 10 — Entregar

1. Commit de todos los cambios:
   ```
   git add .
   git commit -m "Practica1: CRUD [TuModelo] - [TuNombre]"
   ```
2. Push de tu rama:
   ```
   git push origin practica1/tuNombre
   ```
3. Subir el proyecto comprimido como `.zip` al aula virtual junto con capturas de pantalla de cada página funcionando.

---

## Criterios de evaluación

| Criterio | Puntos |
|---|---|
| Proyecto compila sin errores | 10 |
| Página Listar muestra registros en tabla | 15 |
| Página Crear guarda el registro | 15 |
| Página Detalle muestra todos los campos | 10 |
| Página Editar pre-puebla y actualiza | 15 |
| Validadores en el modelo (mínimo 4 propiedades) | 15 |
| Mensajes de validación visibles en formularios | 10 |
| Navegabilidad entre paginas | 10 |
| Puntos EXTRA-  Página Eliminar con confirmación | 5 |
| **Total** | **100** |

---

## Referencia

Para resolver dudas de implementación, revisa el código de los proyectos vistos en clase:
- **Clase 4 y 5 — Portal Estudiantil**: formularios, binding, validación, PRG, TempData
- **Clase 5 — Demo**: handlers, `[BindProperty]`, `ModelState`, `TempData`, `RedirectToPage`

No copies código directamente — úsalos como referencia para entender el patrón y aplícalo a tu modelo.
