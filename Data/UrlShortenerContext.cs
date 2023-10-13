using URLShortener.Entities;
using Microsoft.EntityFrameworkCore;

namespace URLShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<XYZ> XYZs { get; set; }

        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
