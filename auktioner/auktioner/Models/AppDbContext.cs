using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace auktioner.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Test", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Test2", });


        }
    }
}
