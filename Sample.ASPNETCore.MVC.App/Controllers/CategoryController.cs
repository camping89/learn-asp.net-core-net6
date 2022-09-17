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
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("nAmE", $"The display order can't exactly match the name.");
        }

        if (ModelState.IsValid)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            TempData["Success"] = "Category created successfully.";
            return RedirectToAction("Index");
        }

        return View(category);
    }

    #region EDIT

    public IActionResult Edit(int? id)
    {
        if (id is null or 0) return NotFound();
        var current = _db.Categories.Find(id);
        if (current is null) return NotFound();

        return View(current);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("nAmE", $"The display order can't exactly match the name.");
        }

        if (ModelState.IsValid)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["Success"] = "Category updated successfully.";
            return RedirectToAction("Index");
        }

        return View(category);
    }

    #endregion

    #region DELETE

    public IActionResult Delete(int? id)
    {
        if (id is null or 0) return NotFound();
        var current = _db.Categories.Find(id);
        if (current is null) return NotFound();

        return View(current);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        if (id is null or 0) return NotFound();
        var current = _db.Categories.Find(id);
        if (current is null) return NotFound();

        _db.Categories.Remove(current);
        _db.SaveChanges();

        TempData["Success"] = "Category deleted successfully.";
        return RedirectToAction("Index");
    }

    #endregion
}