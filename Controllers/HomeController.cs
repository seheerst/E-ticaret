using EticaretWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EticaretWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace EticaretWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
                ProductId = i.ProductId,
                Name = i.Name.Length > 15 ? i.Name.Substring(0, 47) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Image = i.Image,
                Stock = i.Stock,
                CategoryId = i.CategoryId
            }).ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _context.Products.FindAsync(id));
        }


        public async Task<IActionResult> List(int? id)
        {
            var products = _context.Products.Where(i => i.IsApproved).Select(i => new ProductModel()
            {
                ProductId = i.ProductId,
                Name = i.Name.Length > 15 ? i.Name.Substring(0, 47) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Image = i.Image ?? "1.jpg",
                Stock = i.Stock,
                CategoryId = i.CategoryId
            }).AsQueryable();

            if (id != null)
            {
                products = products.Where(i => i.CategoryId == id);
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(products.ToList());
        }
    }
}