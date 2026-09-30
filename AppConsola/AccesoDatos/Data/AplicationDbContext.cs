using Microsoft.EntityFrameworkCore;
using AccesoDatos.Models;

namespace AccesoDatos.Data
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Artista> Artista { get; set; }
        public DbSet<Cancion> Cancion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\databases\\bade.db");
        }       
    }
}
