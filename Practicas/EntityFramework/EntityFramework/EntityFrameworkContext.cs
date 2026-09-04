using Microsoft.EntityFrameworkCore;

public class EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options) : DbContext(options)
{
    public DbSet<EntityFramework.Models.Mascota> Mascota { get; set; } = default!;
    public DbSet<EntityFramework.Models.HotelCLAS> HotelCLAs { get; set; } = default!;
}
