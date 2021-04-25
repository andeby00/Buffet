using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Controllers
{
    public class RestaurentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
