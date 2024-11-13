using System.ComponentModel.DataAnnotations;

namespace order_system.Models;

public class Role
{
    public int Id { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}
