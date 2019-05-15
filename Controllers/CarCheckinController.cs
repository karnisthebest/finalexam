using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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

        [HttpGet]
        public async Task<IActionResult> ExportExcel()
        {

            //step1: create array to holder header labels
            string[] col_names = new string[]{
                "license no",
                "check in time"
            };
           
            //step2: create result byte array
            byte[] result;

            //step3: create a new package using memory safe structure
            using (var package = new ExcelPackage())
            {
                //step4: create a new worksheet
                var worksheet = package.Workbook.Worksheets.Add("final");

                //step5: fill in header row
                //worksheet.Cells[row,col].  {Style, Value}
                for (int i = 0; i < col_names.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Style.Font.Size = 14;  //font
                    worksheet.Cells[1, i + 1].Value = col_names[i];  //value
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true; //bold
                    //border the cell
                    worksheet.Cells[1, i + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    //set background color for each sell
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 243, 214));

                }
           
   
                int row = 2;
                //step6: loop through query result and fill in cells
                foreach (CarCheckin item in _context.CarCheckins.ToList())
                {
                    for (int col = 1; col <= 2; col++)
                    {
                        worksheet.Cells[row, col].Style.Font.Size = 12;
                        //worksheet.Cells[row, col].Style.Font.Bold = true;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }
                    //set row,column data
                    worksheet.Cells[row, 1].Value = item.checkinLicensePlate;
                    worksheet.Cells[row, 2].Value = item.checkinTime.ToShortTimeString();
                 

                    //toggle background color
                    //even row with ribbon style
                    if (row % 2 == 0)
                    {
                        worksheet.Cells[row, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[row, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(154, 211, 157));

                        worksheet.Cells[row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[row, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(154, 211, 157));
                    
                    }
                    row++;
                }
                //step7: auto fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                //step8: convert the package as byte array
                result = package.GetAsByteArray();
            }//end using

            //step9: return byte array as a file
            return File(result, "application/vnd.ms-excel", "test.xls");



        }//end fun

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
