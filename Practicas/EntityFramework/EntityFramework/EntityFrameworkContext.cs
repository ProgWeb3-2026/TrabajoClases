using Microsoft.EntityFrameworkCore;

public class EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options) : DbContext(options)
{
    public DbSet<EntityFramework.Models.Mascota> Mascota { get; set; } = default!;

    public DbSet<EntityFramework.Models.ClaseHotel> Hotel { get; set; } = default!;
}
