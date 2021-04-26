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

        // GET: Reception/Details
        [Authorize(Policy = "IsReception")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

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

        // GET: Reception/Edit
        [Authorize(Policy = "IsReception")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reception/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "IsReception")]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Date,Adults,Children")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationsExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), reservation); //VED IK
            }
            return View(reservation);  
        }

        // GET: Reception/Delete
        [Authorize(Policy = "IsReception")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reception/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "IsReception")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationsExists(long id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }


    }
}
