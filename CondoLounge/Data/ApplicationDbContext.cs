using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Condo> Condos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>()
                .HasMany(b => b.Condos)
                .WithOne(c => c.Building);

            modelBuilder.Entity<Condo>()
                .HasOne(c => c.Building)
                .WithMany(b => b.Condos);

            modelBuilder.Entity<Condo>()
                .HasMany(c => c.Users)
                .WithMany(u => u.Condos);
        }
    }
}
