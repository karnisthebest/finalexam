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
    public class CarCheckOutController : Controller
    {
        private readonly MISDbContext _context;

        public CarCheckOutController(MISDbContext context)
        {
            _context = context;
        }

        // GET: CarCheckOut
        public IActionResult Index()
        {
            var checkout =_context.CarCheckOuts
                            .Select(x=> new CheckView
                                {
                                    Id= x.checkoutId, //note time is not included just date
                                    licensePlate = x.checkoutLicensePlate,
                                    time = x.checkoutTime.ToShortTimeString(), 

                                });

            return View("Index",checkout);
        }

        // GET: CarCheckOut/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCheckOut = await _context.CarCheckOuts
                .FirstOrDefaultAsync(m => m.checkoutId == id);
            if (carCheckOut == null)
            {
                return NotFound();
            }

            return View(carCheckOut);
        }

        // GET: CarCheckOut/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarCheckOut/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("checkoutId,checkoutLicensePlate,checkoutTime")] CarCheckOut carCheckOut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carCheckOut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carCheckOut);
        }

        // GET: CarCheckOut/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCheckOut = await _context.CarCheckOuts.FindAsync(id);
            if (carCheckOut == null)
            {
                return NotFound();
            }
            return View(carCheckOut);
        }

        // POST: CarCheckOut/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("checkoutId,checkoutLicensePlate,checkoutTime")] CarCheckOut carCheckOut)
        {
            if (id != carCheckOut.checkoutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carCheckOut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarCheckOutExists(carCheckOut.checkoutId))
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
            return View(carCheckOut);
        }

        // GET: CarCheckOut/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCheckOut = await _context.CarCheckOuts
                .FirstOrDefaultAsync(m => m.checkoutId == id);
            if (carCheckOut == null)
            {
                return NotFound();
            }

            return View(carCheckOut);
        }

        // POST: CarCheckOut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carCheckOut = await _context.CarCheckOuts.FindAsync(id);
            _context.CarCheckOuts.Remove(carCheckOut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarCheckOutExists(int id)
        {
            return _context.CarCheckOuts.Any(e => e.checkoutId == id);
        }
    }
}
