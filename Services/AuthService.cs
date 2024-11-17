using order_system.Data;
using order_system.Models;

namespace order_system.Services;

public class AuthService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public User? ValidateAdmin(string username, string password)
    {
        var admin = SearchUserByUsername(username);
        if (admin == null || !VerifyPassword(admin, password) || !IsAdmin(admin)) {
            return null;
        }

        return admin;
    }

    public User? ValidateUser(string email, string password)
    {
        var user = SearchUserByEmail(email);
        if (user == null || !VerifyPassword(user, password) || !IsUser(user)) {
            return null;
        }

        return user;
    }

    private User? SearchUserByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    private User? SearchUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    private static bool VerifyPassword(User user, string password)
    {
        return user.Password == password;
    }

    private static bool IsAdmin(User user)
    {
        return user.RoleId == (int)UserRole.Admin;
    }

    private static bool IsUser(User user)
    {
        return user.RoleId == (int)UserRole.User;
    }

    private enum UserRole
    {
        Admin = 1,
        User = 2,
    }

    public string GetUserRole(int roleId)
    {
        return roleId == (int)UserRole.Admin ? "admin" : "user";
    }

    public bool IsAdminSession(HttpContext context)
    {
        var sessionData = context.Session.GetString("adminSession");
        return sessionData != null;
    }

    public bool IsUserSession(HttpContext context)
    {
        var sessionData = context.Session.GetString("userSession");
        return sessionData != null;
    }
}
