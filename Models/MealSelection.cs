using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace order_system.Models;

public class MealSelection
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public required int UserId { get; set; }
    [ForeignKey("Menu")]
    public required int MenuId { get; set; }
    public required DateTime SelectionDate { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public required DateTime UpdatedAt { get; set; } = DateTime.Now;
    public required User User { get; set; }
    public required Menu Menu { get; set; }
}