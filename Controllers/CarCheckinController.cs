using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class CarCheckinController : Controller
    {
        private readonly MISDbContext _context;

        public CarCheckinController(MISDbContext context)
        {
            _context = context;
        }

        // GET: CarCheckin
        public IActionResult Index()
        {
            var checkin =_context.CarCheckins
                            .Select(x=> new CheckView
                                {
                                    Id= x.checkinId, //note time is not included just date
                                    licensePlate = x.checkinLicensePlate,
                                    time = x.checkinTime.ToShortTimeString(), 

                                });

            return View("Index",checkin);
        }

        // GET: CarCheckin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCheckin = await _context.CarCheckins
                .FirstOrDefaultAsync(m => m.checkinId == id);
            if (carCheckin == null)
            {
                return NotFound();
            }

            return View(carCheckin);
        }

        // GET: CarCheckin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarCheckin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("checkinId,checkinLicensePlate,checkinTime")] CarCheckin carCheckin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carCheckin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carCheckin);
        }

        // GET: CarCheckin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCheckin = await _context.CarCheckins.FindAsync(id);
            if (carCheckin == null)
            {
                return NotFound();
            }
            return View(carCheckin);
        }

        // POST: CarCheckin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("checkinId,checkinLicensePlate,checkinTime")] CarCheckin carCheckin)
        {
            if (id != carCheckin.checkinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carCheckin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarCheckinExists(carCheckin.checkinId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carCheckin);
        }

        // GET: CarCheckin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCheckin = await _context.CarCheckins
                .FirstOrDefaultAsync(m => m.checkinId == id);
            if (carCheckin == null)
            {
                return NotFound();
            }

            return View(carCheckin);
        }

        // POST: CarCheckin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carCheckin = await _context.CarCheckins.FindAsync(id);
            _context.CarCheckins.Remove(carCheckin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarCheckinExists(int id)
        {
            return _context.CarCheckins.Any(e => e.checkinId == id);
        }
    }
}
