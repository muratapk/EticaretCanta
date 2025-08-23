using EticaretCanta.Models;
using Microsoft.EntityFrameworkCore;

namespace EticaretCanta.Data
{
    public class Baglanti : DbContext
    {
        public Baglanti(DbContextOptions<Baglanti> options):base(options)
        {
        }
        public DbSet<Categories>? Categories { get; set; } = null!;
        public DbSet<Sub_Category> Sub_Categories { get; set; }=null!;
        public DbSet<Products> Products { get; set; } = null!;
        public DbSet<Pictures> Pictures { get; set; } = null!;  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(c => c.Sub_Categories)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.Category_Id);

            modelBuilder.Entity<Products>()
                .HasMany(p => p.Pictures)
                .WithOne(b => b.Products)
                .HasForeignKey(m => m.Product_Id);

           modelBuilder.Entity<Sub_Category>()
                .HasMany(c => c.Products)
                .WithOne(b => b.Sub_Category)
                .HasForeignKey(s=> s.Sub_Category_Id);

            modelBuilder.Entity<Categories>()
                 .HasMany(c => c.Products)
                 .WithOne(s => s.Category)
                 .HasForeignKey(s => s.Category_Id);

          modelBuilder.Entity<Products>()
              .Property(p => p.Price)
              .HasPrecision(18, 2);

        }
      
    }
}
