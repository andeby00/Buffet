using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
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

        // GET: Kitchen
        [Authorize(Policy = "IsKitchen")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
