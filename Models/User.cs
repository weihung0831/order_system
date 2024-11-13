using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_system.Models;

public class User
{
    // 為了讓資料表的欄位順序固定，所以使用 Column 屬性
    [Column(Order = 0)]
    public int Id { get; set; }
    [Column(Order = 1)]
    [StringLength(50)]
    public required string Username { get; set; }
    [Column(Order = 2)]
    [StringLength(100)]
    public required string Password { get; set; }
    [Column(Order = 3)]
    [EmailAddress]
    [StringLength(100)]
    public required string Email { get; set; }
    [Column(Order = 4)]
    [ForeignKey("Role")]
    public required int RoleId { get; set; }
    [Column(Order = 5)]
    [Range(0, 1)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Column(Order = 6)]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Column(Order = 7)]
    public Role ? Role { get; set; }
}
