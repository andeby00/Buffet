using Buffet.Data;
using Buffet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Controllers
{
    public class RestaurantController : Controller
    {
        ApplicationDbContext _context;
        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "IsRestaurant")]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Restaurant/Create
        [Authorize(Policy = "IsRestaurant")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "IsRestaurant")]
        public async Task<IActionResult> Create([Bind("Date,RoomNumber,Adults,Children")] CheckedIn checkedIn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkedIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), checkedIn); //VED IK
            }

            return View(checkedIn);
        }
    }
}
