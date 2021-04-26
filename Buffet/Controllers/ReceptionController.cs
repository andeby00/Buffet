using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Models;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Controllers
{
    public class ReceptionController : Controller
    {
         ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "IsReception")]
        public IActionResult Index()
        {
            return View();
        }


        // til alle der læser dette, så er koden til mads' kort 1 3 3 7

        // GET: Reception/Create
        [Authorize(Policy = "IsReception")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reception/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "IsReception")]
        public async Task<IActionResult> Create([Bind("Date,Adults,Children")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), reservation); //VED IK
            }

            return View(reservation);
        }

        [Authorize(Policy = "IsReception")]
        public IActionResult Details()
        {
            return View();
        }

        // POST: Reception/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "IsReception")]
        public async Task<IActionResult> Details([Bind("Date,Adults,Children,RoomNumber")] CheckedIn checkedIn)
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
