using Microsoft.EntityFrameworkCore;
using C_Project1.Models;

namespace C_Project1.Data
{
    public class DbDataContext : DbContext
    {
        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options) { }

        public DbSet<ProductInfoModel> Products { get; set; }
        public DbSet<ProductCartModel> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCartModel>()
                .HasOne(c => c.Product)
                .WithMany() 
                .HasForeignKey(c => c.ProductId);
        }
    }
}
