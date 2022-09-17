using Microsoft.AspNetCore.Mvc;
using Sample.ASPNETCore.MVC.App.Data;

namespace Sample.ASPNETCore.MVC.App.Controllers;

public class CategoryController : Controller
{
    private readonly AppDbContext _db;

    public CategoryController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var categories = _db.Categories.ToList();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }
}