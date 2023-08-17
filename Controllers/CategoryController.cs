using System.Net;
using EticaretWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticaretWeb.Controllers;

public class CategoryController : Controller
{
    private readonly DataContext _context;
    
    public CategoryController(DataContext context)
    {
        _context = context;
    }
  
    public ActionResult Index()
    {
        return View(_context.Categories.ToList());
    }
    
    
    public ActionResult Details(int? id)
    {
     
        Category category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
    
    public ActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create( Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(new Category()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,

            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View();
    }
    
    public ActionResult Edit(int? id)
    {
      
        Category category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id , Category category)
    {
        if (id != category.CategoryId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(new Category()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                });
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Categories.Any(s=> s.CategoryId == category.CategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Index");
        }

        return View(category);

    }
    
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            Results.StatusCode((int)HttpStatusCode.BadRequest);
        }
        Category category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Category category = _context.Categories.Find(id)!;
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
        base.Dispose(disposing);
    }
    
    
}