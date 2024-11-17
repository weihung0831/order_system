using Microsoft.AspNetCore.Mvc;
using order_system.Models;
using order_system.Services;
using Swashbuckle.AspNetCore.Annotations;
namespace order_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController(MenuService menuService, AuthService authService) : Controller
{
    private readonly MenuService _menuService = menuService;
    private readonly AuthService _authService = authService;

    [HttpPost("admin/create")]
    [SwaggerOperation(Summary = "新增菜單")]
    [SwaggerResponse(200, "Menu created successfully", typeof(Menu))]
    [SwaggerResponse(401, "No session data found")]
    [SwaggerResponse(400, "Failed to create menu")]
    public IActionResult Create([FromBody] MenuDto menuDto)
    {
        if (!_authService.IsAdminSession(HttpContext)) return Unauthorized(new { message = "No session data found" });

        try
        {
            var menu = _menuService.CreateMenu(menuDto);
            return Ok(new { 
                message = "Menu created successfully", 
                menu 
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Failed to create menu: " + ex.Message });
        }
    }

    [HttpDelete("admin/delete/{id}")]
    [SwaggerOperation(Summary = "刪除菜單")]
    [SwaggerResponse(200, "Menu deleted")]
    [SwaggerResponse(401, "No session data found")]
    [SwaggerResponse(400, "Failed to delete menu")]
    public IActionResult Delete(int id)
    {
        if (!_authService.IsAdminSession(HttpContext)) return Unauthorized(new { message = "No session data found" });

        try
        {
            _menuService.DeleteMenu(id);
            return Ok(new { message = "Menu deleted" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Failed to delete menu: " + ex.Message });
        }
    }

    [HttpPut("admin/update/{id}")]
    [SwaggerOperation(Summary = "更新菜單")]
    [SwaggerResponse(200, "Menu updated")]
    [SwaggerResponse(401, "No session data found")]
    [SwaggerResponse(400, "Failed to update menu")]
    public IActionResult Update(int id, [FromBody] MenuDto menuDto)
    {
        if (!_authService.IsAdminSession(HttpContext)) return Unauthorized(new { message = "No session data found" });

        try
        {
            _menuService.UpdateMenu(id, menuDto);
            return Ok(new { message = "Menu updated" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Failed to update menu: " + ex.Message });
        }
    }

    [HttpGet("list")]
    [SwaggerOperation(Summary = "取得本週菜單列表")]
    [SwaggerResponse(200, "Menu list", typeof(List<Menu>))]
    [SwaggerResponse(401, "No session data found")]
    [SwaggerResponse(400, "Failed to get menu list")]
    public IActionResult List([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        if (!_authService.IsUserSession(HttpContext)) return Unauthorized(new { message = "No session data found" });

        try
        {
            var menus = _menuService.GetMenus(page, pageSize, isThisWeek: true);
            return Ok(new { 
                message = "Success get menu list", 
                menus 
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Failed to get menu list: " + ex.Message });
        }
    }
}
