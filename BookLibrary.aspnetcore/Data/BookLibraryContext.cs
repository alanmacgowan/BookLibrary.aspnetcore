using BookLibrary.aspnetcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Data
{
    public class BookLibraryContext : DbContext
    {
        public BookLibraryContext(DbContextOptions<BookLibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Book>().ToTable("Book");
        }
    }
}
