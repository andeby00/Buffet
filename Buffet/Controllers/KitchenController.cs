using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;

namespace Buffet.Controllers
{
    public class KitchenController : Controller
    {
        ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
