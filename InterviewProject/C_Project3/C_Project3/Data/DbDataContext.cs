using Microsoft.EntityFrameworkCore;
using C_Project3.Models;

namespace C_Project3.Data
{
    public class DbDataContext : DbContext
    {
        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options) { }

        public DbSet<BookInfoModel> Books { get; set; }
        public DbSet<BookBorrowModel> BookBorrow { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookBorrowModel>()
                .HasOne(c => c.BookInfo)
                .WithMany() 
                .HasForeignKey(c => c.BookId);
        }
    }
}
