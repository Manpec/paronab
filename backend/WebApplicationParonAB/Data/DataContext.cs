using Microsoft.EntityFrameworkCore;
using WebApplicationParonAB.Models;

namespace WebApplicationParonAB.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Produkter> Produkter {get; set;}
        public DbSet<Lagersaldo> Lagersaldo {get; set;}
        public DbSet<InOchUtLeverans> InOchUtLeverans { get; set; }
        public DbSet<Fardigvarulager> Fardigvarulager { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produkter>()
               .HasIndex(e => e.Benamning)
               .IsUnique();

            modelBuilder.Entity<Fardigvarulager>()
                .HasIndex(e => e.Stad)
                .IsUnique();

            modelBuilder.Entity<Lagersaldo>()
               .HasIndex(l => new { l.Produkt, l.Fardigvarulager })
               .IsUnique();

            modelBuilder.Entity<Produkter>().HasData(
            new Produkter
            {
                Produktnr = "P001",
                Benamning = "jTelefon",
                Pris = 6000
            }
        );
            modelBuilder.Entity<Produkter>().HasData(
           new Produkter
           {
               Produktnr = "P002",
               Benamning = "jPlatta",
               Pris = 8000
           }
       );

            modelBuilder.Entity<Produkter>().HasData(
          new Produkter
          {
              Produktnr = "P003",
              Benamning = "Päronklocka",
              Pris = 12000
          }
      );

            base.OnModelCreating(modelBuilder);
        }


    }
}
