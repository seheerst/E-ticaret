using EticaretWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EticaretWeb.Controllers
{
    public class HomeController : Controller
    {
     

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Details()
        {
            return View();
        }


        public IActionResult List()
        {
            return View();
        }
       
    }
}