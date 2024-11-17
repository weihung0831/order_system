using Microsoft.AspNetCore.Mvc;
using order_system.Services;
using order_system.Models;
using Swashbuckle.AspNetCore.Annotations;
using order_system.Data;

namespace order_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MealSelectionController(MealSelectionService mealSelectionService, AuthService authService, MenuService menuService, AppDbContext context) : Controller
{
    private readonly MealSelectionService _mealSelectionService = mealSelectionService;
    private readonly AuthService _authService = authService;
    private readonly MenuService _menuService = menuService;
    private readonly AppDbContext _context = context;

    [HttpPost("create")]
    [SwaggerOperation(Summary = "新增選擇的餐點")]
    [SwaggerResponse(200, "Meal selection created successfully", typeof(MealSelection))]
    [SwaggerResponse(401, "No session data found")]
    [SwaggerResponse(400, "Failed to create meal selection")]
    public IActionResult Create([FromBody] MealSelectionDto mealSelectionDto)
    {
        if (!_authService.IsUserSession(HttpContext)) return Unauthorized(new { message = "No session data found" });

        // 檢查在本週是否在同一天已經選擇過餐點
        var existingSelection = _context.MealSelections.FirstOrDefault(ms =>
            ms.UserId == mealSelectionDto.UserId &&
            ms.SelectionDate == MealSelectionService.GetWeekdayString(mealSelectionDto.SelectionDate)
        );
        if (existingSelection != null) return BadRequest(new { message = "You have already selected a meal for this day" });

        try
        {
            var mealSelection = _mealSelectionService.CreateMealSelection(mealSelectionDto);
            if (mealSelection == null) return BadRequest(new { message = "Invalid selection date" });
            return Ok(new { 
                message = "Meal selection created successfully", 
                mealSelection 
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Failed to create meal selection: " + ex.Message });
        }
    }

    [HttpGet("history/{userId}")]
    [SwaggerOperation(Summary = "取得選擇的餐點歷史")]
    [SwaggerResponse(200, "Meal selection history retrieved successfully", typeof(List<MealSelection>))]
    [SwaggerResponse(401, "No session data found")]
    [SwaggerResponse(400, "Failed to get meal selection history")]
    public IActionResult GetHistory(int userId, int page = 1, int pageSize = 10)
    {
        if (!_authService.IsUserSession(HttpContext)) return Unauthorized(new { message = "No session data found" });

        try
        {
            var mealSelections = _mealSelectionService.GetMealSelections(userId, page, pageSize);
            return Ok(new { 
                message = "Meal selection history retrieved successfully", 
                mealSelections 
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Failed to get meal selection history: " + ex.Message });
        }
    }

    [HttpPut("edit/{id}")]
    [SwaggerOperation(Summary = "編輯選擇的餐點")]
    [SwaggerResponse(200, "Meal selection edited successfully", typeof(MealSelection))]
    [SwaggerResponse(401, "No session data found")]
    [SwaggerResponse(400, "Failed to edit meal selection")]
    public IActionResult Edit(int id, [FromBody] MealSelectionDto mealSelectionDto)
    {
        if (!_authService.IsUserSession(HttpContext)) return Unauthorized(new { message = "No session data found" });

        try
        {
            var mealSelection = _mealSelectionService.EditMealSelection(id, mealSelectionDto);
            return Ok(new { 
                message = "Meal selection edited successfully", 
                mealSelection 
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Failed to edit meal selection: " + ex.Message });
        }
    }
}
