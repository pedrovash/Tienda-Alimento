using Microsoft.EntityFrameworkCore;

namespace Eva02Comida.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Marca> tblMarcas { get; set; }
        public DbSet<Edad> tblEdades { get; set; }
        public DbSet<Especie> tblEspecies { get; set; }

        public DbSet<Formato> tblFormatos { get; set; }
        public DbSet<Alimento> tblAlimentos { get; set; }

        public DbSet<Usuario> tblUsuarios { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration
                .GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
