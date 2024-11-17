using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using order_system.Models;
using order_system.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace order_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthService authService) : Controller
{
    private readonly AuthService _authService = authService;

    [HttpPost("admin/login")]
    [SwaggerOperation(Summary = "管理員登入")]
    [SwaggerResponse(200, "Login successful", typeof(UserSessionDto))]
    [SwaggerResponse(401, "Login failed")]
    public IActionResult AdminLogin([FromBody] AdminDto adminDto)
    {
        var user = _authService.ValidateAdmin(adminDto.Username, adminDto.Password);
        if (user == null) return Unauthorized(new { message = "Login failed" });

        var data = new AdminSessionDto
        {
            Username = user.Username,
            RoleId = user.RoleId,
            LoginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        };
        var serializedData = JsonSerializer.Serialize(data);
        HttpContext.Session.SetString("adminSession", serializedData);

        var role = _authService.GetUserRole(user.RoleId);

        return Ok(new { 
            message = "Login successful",
            role = role,
            session = JsonSerializer.Deserialize<AdminSessionDto>(serializedData)
        });
    }

    [HttpPost("admin/logout")]
    [SwaggerOperation(Summary = "管理員登出")]
    [SwaggerResponse(200, "Logout successful")]
    [SwaggerResponse(401, "No session data found")]
    public IActionResult AdminLogout()
    {
        if (!_authService.IsAdminSession(HttpContext)) return Unauthorized(new { message = "No session data found" });

        HttpContext.Session.Clear();
        return Ok(new { message = "Logout successful" });
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = "使用者登入")]
    [SwaggerResponse(200, "Login successful", typeof(UserSessionDto))]
    [SwaggerResponse(401, "Login failed")]
    public IActionResult UserLogin([FromBody] UserDto userDto)
    {
        var user = _authService.ValidateUser(userDto.Email, userDto.Password);
        if (user == null) return Unauthorized(new { message = "Login failed" });

        var data = new UserSessionDto
        {
            Username = user.Username,
            Email = user.Email,
            RoleId = user.RoleId,
            LoginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        };

        var serializedData = JsonSerializer.Serialize(data);
        HttpContext.Session.SetString("userSession", serializedData);

        var role = _authService.GetUserRole(user.RoleId);

        return Ok(new { 
            message = "Login successful", 
            role = role,
            session = JsonSerializer.Deserialize<UserSessionDto>(serializedData)
        });
    }

    [HttpPost("logout")]
    [SwaggerOperation(Summary = "使用者登出")]
    [SwaggerResponse(200, "Logout successful")]
    [SwaggerResponse(401, "No session data found")]
    public IActionResult UserLogout()
    {
        if (!_authService.IsUserSession(HttpContext)) return Unauthorized(new { message = "No session data found" });

        HttpContext.Session.Clear();
        return Ok(new { message = "Logout successful" });
    }

    [HttpGet("getSession")]
    [SwaggerOperation(Summary = "取得 session")]
    [SwaggerResponse(200, "Session data", typeof(string))]
    [SwaggerResponse(401, "No session data found")]
    public IActionResult GetSessionData()
    {
        var userSessionData = HttpContext.Session.GetString("userSession") ?? throw new Exception("No session data found");
        var adminSessionData = HttpContext.Session.GetString("adminSession") ?? throw new Exception("No session data found");

        return Ok(new {
            message = "Success", 
            userSession = JsonSerializer.Deserialize<UserSessionDto>(userSessionData),
            adminSession = JsonSerializer.Deserialize<AdminSessionDto>(adminSessionData)
        });
    }
}
