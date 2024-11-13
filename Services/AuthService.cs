using order_system.Data;
using order_system.Models;

namespace order_system.Services;

public class AuthService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public User? ValidateAdmin(string username, string password)
    {
        var user = SearchUserByUsername(username);
        if (user == null || !VerifyPassword(user, password) || !IsAdmin(user)) {
            return null;
        }

        return user;
    }

    private User? SearchUserByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    private static bool VerifyPassword(User user, string password)
    {
        return user.Password == password;
    }

    private static bool IsAdmin(User user)
    {
        return user.RoleId == 1;
    }
}
