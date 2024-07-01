using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zoo.Models;
using Zoo.Data;
using Microsoft.EntityFrameworkCore;

namespace Zoo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ZooContext _context;

        public HomeController(ILogger<HomeController> logger, ZooContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Zoos = _context.ZooModel.ToList();
            ViewBag.Species = _context.Species.ToList();
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Enclosures = _context.Enclosure.ToList();
            ViewBag.Animals = _context.Animal.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
