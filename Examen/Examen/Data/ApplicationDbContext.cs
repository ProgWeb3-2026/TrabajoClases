using Examen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Examen.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Inmueble> Inmuebke { get; set; } = default!;
        public DbSet<Tarea> Tarea { get; set; } = default!;
    }
}
