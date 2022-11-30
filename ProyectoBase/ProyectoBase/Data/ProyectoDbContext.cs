using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models.Entidades;

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
    }
}