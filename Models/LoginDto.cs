using System.ComponentModel.DataAnnotations;

namespace order_system.Models;

public class LoginDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
