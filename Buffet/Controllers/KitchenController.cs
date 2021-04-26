using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Buffet.Data;
using Buffet.Models;
using Microsoft.AspNetCore.Authorization;

namespace Buffet.Controllers
{
    public class KitchenController : Controller
    {
        ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "IsKitchen")]
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Details(DateTime date)
        {
            var vm = new KitchenViewModel()
            {
                Reservations = _context.Reservations.Where(r => r.Date >= date.Date && r.Date < date.Date.AddDays(1)).ToList(),
                CheckedIns = _context.CheckedIns.Where(r => r.Date >= date.Date && r.Date < date.Date.AddDays(1)).ToList(),
                Date = date
            };
            return View(vm);
        }
    }
}
