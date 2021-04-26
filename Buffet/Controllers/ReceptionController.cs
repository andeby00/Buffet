using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Controllers
{
    public class ReceptionController : Controller
    {
        [Authorize(Policy = "IsKitchen")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
