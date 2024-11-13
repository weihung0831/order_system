namespace order_system.Models;

public class UserSessionDto
{
    public required string Username { get; set; }
    public required int RoleId { get; set; }
    public required string LoginTime { get; set; }
}
