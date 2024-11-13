using Microsoft.EntityFrameworkCore;
using order_system.Models;

namespace order_system.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<MealSelection> MealSelections { get; set; }
    public DbSet<Menu> Menus { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "admin" },
            new Role { Id = 2, Name = "user" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { 
                Id = 1, 
                Username = "admin", 
                Password = "123456", 
                Email = "admin@example.com",
                RoleId = 1,
                CreatedAt = DateTime.Now, 
                UpdatedAt = DateTime.Now,
            }
        );
    }
}
