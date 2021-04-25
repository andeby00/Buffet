using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
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

        [Authorize(Policy = "IsKitchen")]
        public async Task<IActionResult> Index()
        {
            return (View(await _context.reservations.ToListAsync()), View(await _context.receptions.ToListAsync()));
        }

        //public IActionResult Index()
        //{ return View(); }
    }
}
