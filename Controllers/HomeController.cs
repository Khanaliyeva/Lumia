
using Lumia.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lumia.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var teams=_context.Teams.ToList();
            return View(teams);
        }
    }
}