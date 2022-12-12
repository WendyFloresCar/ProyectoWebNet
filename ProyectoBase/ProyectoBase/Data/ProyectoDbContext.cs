using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models.Entidades;
using ProyectoBase.Models.Entidades.SP;

namespace ProyectoBase.Data
{
    public class ProyectoDbContext : DbContext
    {
        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Trabajador> Trabajador { get; set; }
        public DbSet<Sede> Sede { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<sp_trabajador> sp_trabajador { get; set; }
        public DbSet<perfiles> perfiles { get; set; }
    }
}