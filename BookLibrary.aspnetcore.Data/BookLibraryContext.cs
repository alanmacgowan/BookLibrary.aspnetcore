using BookLibrary.aspnetcore.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.aspnetcore.Data
{
    public class BookLibraryContext : IdentityDbContext<ApplicationUser>
    {
        public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
            : base(options)
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

            modelBuilder.Entity<ApplicationUser>().ToTable("User").HasKey(u => u.Id);
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole").HasKey(u => new { u.UserId, u.RoleId });
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin").HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken").HasKey(u => new { u.LoginProvider, u.UserId });

            //modelBuilder.Entity<ApplicationUser>(entity =>
            //{
            //    entity.ToTable(name: "Users");
            //   // entity.Property(e => e.Id).HasColumnName("UserId");
            //});

            //modelBuilder.Entity<IdentityRole>(entity =>
            //{
            //    entity.ToTable(name: "Roles");
            //    //entity.Property(e => e.Id).HasColumnName("RoleId");
            //});

            //modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            //{
            //    entity.ToTable("UserRoles");
            //    //entity.HasKey(key => new { key.UserId, key.RoleId });
            //});

            //modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            //{
            //    entity.ToTable("UserClaims");
            //});

            //modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            //{
            //    entity.ToTable("UserLogins");
            //});

            //modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            //{
            //    entity.ToTable("RoleClaims");
            //});

            //modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            //{
            //    entity.ToTable("UserTokens");
            //});
        }
    }
}
