namespace order_system.Models;

public class AdminDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class AdminSessionDto
{
    public required string Username { get; set; }
    public required int RoleId { get; set; }
    public required string LoginTime { get; set; }
}
