using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Data
{
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext (DbContextOptions<EntityFrameworkContext> options)
            : base(options)
        {
        }

        public DbSet<EntityFramework.Models.Mascota> Mascota { get; set; } = default!;
        public DbSet<EntityFramework.Models.hotel> hotel { get; set; } = default!;
    }
}
