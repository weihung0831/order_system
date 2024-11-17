using order_system.Data;
using order_system.Models;

namespace order_system.Services;

public class MenuService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public Menu CreateMenu(MenuDto menuDto)
    {
        var menu = new Menu
        {
            Name = menuDto.Name,
            Description = menuDto.Description,
            Price = menuDto.Price,
            IsAvailable = menuDto.IsAvailable,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        _context.Menus.Add(menu);
        _context.SaveChanges();
        return menu;
    }

    public void DeleteMenu(int id)
    {
        var menu = _context.Menus.Find(id) ?? throw new Exception("Menu not found");
        _context.Menus.Remove(menu);
        _context.SaveChanges();
    }

    public void UpdateMenu(int id, MenuDto menuDto)
    {
        var menu = _context.Menus.Find(id) ?? throw new Exception("Menu not found");
        menu.Name = menuDto.Name;
        menu.Description = menuDto.Description;
        menu.Price = menuDto.Price;
        menu.IsAvailable = menuDto.IsAvailable;
        menu.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
    }

    public List<Menu> GetMenus(int page, int pageSize, bool isThisWeek = false)
    {
        var query = _context.Menus.AsQueryable();

        if (isThisWeek)
        {
            // 取得本周的日期範圍
            var startOfWeek = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek + (int)DayOfWeek.Monday).ToLocalTime();
            // 取得本周的結束日期
            var endOfWeek = startOfWeek.AddDays(5);
            query = query.Where(m => m.CreatedAt.Date >= startOfWeek && m.CreatedAt.Date <= endOfWeek);
        }

        var data = query
            .OrderByDescending(m => m.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return data;
    }
}
