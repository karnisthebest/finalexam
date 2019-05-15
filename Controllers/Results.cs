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
    //step12: auto gen product controller and respective crud views using
    //at your command prompt, enter the following command
    //dotnet aspnet-codegenerator controller -name ProductController -actions -m Product -dc MISDbContext -outDir Controllers

    public class ResultsController : Controller
    {
        private readonly MISDbContext _context;

        public ResultsController(MISDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> products(){
            var result = await _context.products.ToListAsync();
            return Json(result);
        }
        // GET: Product
        public IActionResult Index()
        {

             var getCheckInCount = _context.CarCheckins.Select(x => x)
                                .GroupBy(x => x.checkinLicensePlate)
                                .Select(g=> new CheckView{
                                    licensePlate = g.Key,
                                    count = g.Count()
                                })
                                .Where(x => x.count > 1).ToList();
                    
            // ViewData["Frequent"] = getCheckInCount.Where(x => x.count > 1);
         

            

            return View(getCheckInCount);
        }

        public IActionResult multiple()
        {

             var getCheckInCount = _context.CarCheckins.Select(x => x)
                                .GroupBy(x => x.checkinLicensePlate)
                                .Select(g=> new CheckView{
                                    licensePlate = g.Key,
                                    count = g.Count()
                                })
                                .Where(x => x.count > 1).ToList();
                    

            return View(getCheckInCount);
        }

        public IActionResult before()
        {
            //get all checkins
            var getCheckin = _context.CarCheckins.Select(x =>x);

            // 13:30
            var myTime = new DateTime(2008,4,1, 13, 30, 0);

            //convert checkin into hour and minutes that has same dd mm yy as myTime
            var checkinTimes = getCheckin
                                .Select(x => new CheckView {
                                    licensePlate = x.checkinLicensePlate,
                                    hour = new DateTime(2008,4,1, x.checkinTime.Hour, x.checkinTime.Minute, 0),
                                });

            // get checkin less than 13:30
            var checkinBefore = checkinTimes
                                    .Where(x => x.hour < myTime)
                                    .ToList();

            // count total checkin before 13:30
            var checkinCount = checkinBefore.Count();


            //get all checkout
            var getCheckout = _context.CarCheckOuts.Select(x =>x);

            

            //convert checkin into hour and minutes that has same dd mm yy as myTime
            var checkoutTimes = getCheckout
                                .Select(x => new CheckView {
                                    licensePlate = x.checkoutLicensePlate,
                                    hour = new DateTime(2008,4,1, x.checkoutTime.Hour, x.checkoutTime.Minute, 0),
                                });

            // get checkin less than 13:30
            var checkoutBefore = checkoutTimes
                                    .Where(x => x.hour < myTime)
                                    .ToList();
                                    
            // count total checkin before 13:30
            var checkoutCount = checkoutBefore.Count();

            var parkingSpace = 20 - (checkinCount - checkoutCount);

           
            ViewData["ParkingSpace"] = parkingSpace;
           

          

            return View();

            
            // if(d1 != null && d2 != null){
            //     DateTime date1 = Convert.ToDateTime(d1);
            //     DateTime date2 = Convert.ToDateTime(d2);
            //     set1 = set1.Where(x => x.createdDate >= date1 && x.createdDate <= date2);
            // }

        }

        
        public IActionResult data()
        {
            var getCheckInCount = _context.CarCheckins.Select(x => x)
                                .GroupBy(x => x.checkinLicensePlate)
                                .Select(g=> new {
                                    license = g.Key,
                                    count = g.Count()
                                });
                    
            var frequent = getCheckInCount.Where(x => x.count > 1).FirstOrDefault();


            return Json(frequent);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .FirstOrDefaultAsync(m => m.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Product product)
        {
            if (ModelState.IsValid)
            {
                product.createdDate = DateTime.Now;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productId,productName,productQty,productPrice,createdDate")] Product product)
        {
            if (id != product.productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.productId))
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
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .FirstOrDefaultAsync(m => m.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.products.FindAsync(id);
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.productId == id);
        }
    }
}
