using Microsoft.EntityFrameworkCore;

namespace CrudTransaccion.Models
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Transaccional;Trusted_Connection=true;Encrypt = False;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Libro>().HasKey(v => v.Libroid);

        }

    }
}
