using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fix MySQL Incompatibilities
            modelBuilder.Entity<IdentityRole>()
                .Property(r => r.ConcurrencyStamp)
                .HasColumnType("longtext");

            modelBuilder.Entity<IdentityUser>()
                .Property(u => u.ConcurrencyStamp)
                .HasColumnType("longtext");

            modelBuilder.Entity<IdentityUser>()
                .Property(u => u.PhoneNumber)
                .HasColumnType("longtext");
        }
    }
}
