using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace order_system.Models;

public class Menu
{
    public int Id { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }
    [StringLength(255)]
    public required string Description { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public required decimal Price { get; set; }
    public required bool IsAvailable { get; set; } = true;
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public required DateTime UpdatedAt { get; set; } = DateTime.Now;
}

public class MenuDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required bool IsAvailable { get; set; } = true;
}