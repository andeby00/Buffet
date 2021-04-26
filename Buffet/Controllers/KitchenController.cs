using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Controllers
{
    public class KitchenController : Controller
    {
        ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[Authorize(Policy = "IsKitchen")]
        //public async Task<IActionResult> Index()
        //{
        //    return (View(await _context.reservations.ToListAsync()), View(await _context.receptions.ToListAsync()));
        //}

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
                 res = _context.Bookings.Where(b => b.BookingDate >= Date.Date && b.BookingDate < filterDate).ToList();
        }
            return View(vm);
        }
    }
}
