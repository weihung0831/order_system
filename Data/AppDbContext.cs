using Microsoft.EntityFrameworkCore;
using order_system.Models;

namespace order_system.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public required DbSet<User> Users { get; set; }
    public required DbSet<Role> Roles { get; set; }
    public required DbSet<MealSelection> MealSelections { get; set; }
    public required DbSet<Menu> Menus { get; set; }
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

        for (int i = 0; i < 10; i++) {
            modelBuilder.Entity<User>().HasData(
                new User { 
                    Id = i + 2,
                    Username = $"user{i}", 
                    Password = "123456", 
                    Email = $"user{i}@example.com", 
                    RoleId = 2, 
                    CreatedAt = DateTime.Now, 
                    UpdatedAt = DateTime.Now 
                }
            );
        }
    }
}
