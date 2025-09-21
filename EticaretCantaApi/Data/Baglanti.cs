using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EticaretCantaApi.Models;
namespace EticaretCantaApi.Data
{
    public class Baglanti:DbContext
    {
        public Baglanti(DbContextOptions<Baglanti> options) : base(options)
        {
        }
        public DbSet<Categories>? Categories { get; set; } = null!;
        public DbSet<Sub_Category> Sub_Categories { get; set; } = null!;
        public DbSet<Products> Products { get; set; } = null!;
        public DbSet<Pictures> Pictures { get; set; } = null!;
    }
}
