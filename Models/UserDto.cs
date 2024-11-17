namespace order_system.Models;

public class UserDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class UserSessionDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required int RoleId { get; set; }
    public required string LoginTime { get; set; }
}
