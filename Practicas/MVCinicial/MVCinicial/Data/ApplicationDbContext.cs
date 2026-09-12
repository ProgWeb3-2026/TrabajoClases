using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCinicial.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<MVCinicial.Models.Contacto> Contacto { get; set; } = default!;

        public DbSet<MVCinicial.Models.Empleado> Empleado { get; set; } = default!;

        public DbSet<MVCinicial.Models.Cargo> Cargo { get; set; } = default!;

    }
}
