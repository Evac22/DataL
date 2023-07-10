using DataSchemaLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DataSchemaLibrary.DataAccess
{
    public class DataSchemaLibraryDbContext : DbContext
    {
        public DataSchemaLibraryDbContext(DbContextOptions<DataSchemaLibraryDbContext> options) : base(options)
        {

        }

        // DbSet для каждой модели, которую вы хотите сохранить в базе данных
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //отношения между таблицами и другие настройки
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
