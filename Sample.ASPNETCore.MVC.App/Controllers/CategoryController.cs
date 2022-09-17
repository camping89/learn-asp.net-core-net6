using Microsoft.AspNetCore.Mvc;
using Sample.ASPNETCore.MVC.App.Data;
using Sample.ASPNETCore.MVC.App.Models;

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

    [HttpPost]

    // already use setup at program.cs for this [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        // if (category.Name.Equals(category.DisplayOrder.ToString(),StringComparison.InvariantCultureIgnoreCase))
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("nAmE", $"The display order can't exactly match the name.");
        }

        if (ModelState.IsValid)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(category);
    }
}