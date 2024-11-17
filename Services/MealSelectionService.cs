using System.Text.Json;
using order_system.Data;
using order_system.Models;

namespace order_system.Services;

public class MealSelectionService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public MealSelection? CreateMealSelection(MealSelectionDto mealSelectionDto)
    {
        var user = _context.Users.Find(mealSelectionDto.UserId) ?? throw new Exception("User not found");
        var menu = _context.Menus.Find(mealSelectionDto.MenuId) ?? throw new Exception("Menu not found");

        var mealSelection = new MealSelection
        {
            UserId = mealSelectionDto.UserId,
            MenuId = mealSelectionDto.MenuId,
            SelectionDate = "",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        mealSelection.SelectionDate = GetWeekdayString(mealSelectionDto.SelectionDate);

        _context.MealSelections.Add(mealSelection);
        _context.SaveChanges();
        return mealSelection;
    }

    public List<MealSelection> GetMealSelections(int userId, int page, int pageSize)
    {
        return _context.MealSelections
            .Where(ms => ms.UserId == userId)
            .OrderByDescending(ms => ms.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public static string GetWeekdayString(int selectionDate)
    {
        return selectionDate switch
        {
            1 => "星期一",
            2 => "星期二",
            3 => "星期三",
            4 => "星期四",
            5 => "星期五",
            _ => throw new ArgumentException(
                JsonSerializer.Serialize(new {
                    error = "Invalid selection date",
                    message = "Selection date must be between 1 and 5"
                })
            ),
        };
    }

    public MealSelection EditMealSelection(int id, MealSelectionDto mealSelectionDto)
    {
        var mealSelection = _context.MealSelections.Find(id) ?? throw new Exception("Meal selection not found");
        mealSelection.MenuId = mealSelectionDto.MenuId;
        mealSelection.UserId = mealSelectionDto.UserId;
        mealSelection.SelectionDate = GetWeekdayString(mealSelectionDto.SelectionDate);
        mealSelection.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return mealSelection;
    }
}
