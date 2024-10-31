using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst.Models
{
    public class EFCodeFirstContext : DbContext
    {
        public EFCodeFirstContext()
        {
        }

        public EFCodeFirstContext(DbContextOptions<EFCodeFirstContext> options)
            : base(options)
        {
        }

        public DbSet<Prodotto> Prodotti { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}

