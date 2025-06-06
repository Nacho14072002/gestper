using Gestper.Models;
using Microsoft.EntityFrameworkCore;


namespace Gestper.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignacion>().HasNoKey();
        }



        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
    

    }

}
