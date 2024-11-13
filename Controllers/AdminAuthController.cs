using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using order_system.Models;
using order_system.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace order_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminAuthController(AuthService authService) : Controller
{
    private readonly AuthService _authService = authService;

    [HttpPost("login")]
    [SwaggerOperation(Summary = "管理員登入")]
    [SwaggerResponse(200, "Login successful", typeof(UserSessionDto))]
    [SwaggerResponse(401, "Login failed")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var user = _authService.ValidateAdmin(loginDto.Username, loginDto.Password);
        if (user == null) return Unauthorized(new { message = "Login failed" });

        var data = new UserSessionDto
        {
            Username = user.Username,
            RoleId = user.RoleId,
            LoginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        };
        var serializedData = JsonSerializer.Serialize(data);
        HttpContext.Session.SetString("adminSession", serializedData);

        return Ok(new { 
            message = "Login successful", 
            session = JsonSerializer.Deserialize<UserSessionDto>(serializedData) 
        });
    }

    [HttpPost("logout")]
    [SwaggerOperation(Summary = "管理員登出")]
    [SwaggerResponse(200, "Logout successful")]
    [SwaggerResponse(401, "No session data found")]
    public IActionResult Logout()
    {
        var sessionData = HttpContext.Session.GetString("adminSession");
        if (sessionData == null) return Unauthorized(new { message = "No session data found" });

        HttpContext.Session.Remove("adminSession");
        return Ok(new { message = "Logout successful" });
    }

    [HttpGet("getSession")]
    [SwaggerOperation(Summary = "測試是否有管理員 session")]
    [SwaggerResponse(200, "Success", typeof(UserSessionDto))]
    [SwaggerResponse(401, "No session data found")]
    public IActionResult GetSession()
    {
        var sessionData = HttpContext.Session.GetString("adminSession");
        if (sessionData == null) return Unauthorized(new { message = "No session data found" });
        return Ok(new { message = "Success", session = JsonSerializer.Deserialize<UserSessionDto>(sessionData) });
    }
}
