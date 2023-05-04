using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Core.Entities;
using Garage3._0.Core.ViewModels;
using Garage_2._0.Data;
using System.Globalization;

namespace Garage_2._0.Controllers
{
    public class UsersController : Controller
    {
        private readonly Garage_2_0Context _context;
        private DateTime dt;

        public UsersController(Garage_2_0Context context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.Select(v => new UserViewModel
            {
                Id = v.Id,
                UserName = v.UserName,
                Fname = v.Fname,
                Lname = v.Lname,
                Pnr = v.Pnr
            }).ToListAsync());

                //return _context.User != null ?
                //            View(await _context.User.ToListAsync()) :
                //            Problem("Entity set 'Garage_2_0Context.User'  is null.");
            }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            //var viewModel = new UserDetailViewModel
            //{
            //    Id = user.Id,
            //    UserName = user.UserName,
            //    Fname = user.Fname,
            //    Lname = user.Lname,
            //    Pnr = user.Pnr,

            //    Vehicles = user.Vehicles.Select(v => new Vehicle
                
            //    )
            //};

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Fname,Lname,Pnr")] User user)
        {
           if(ValidatePersNr(user.Pnr))
            {
                ModelState.AddModelError("Pnr", "Error! The personal number already exists!");
            }

            if (ModelState.IsValid)
            {
          
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        private bool ValidatePersNr(string pnr)
        {
            return _context.User.Any(u => u.Pnr == pnr);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Fname,Lname,Pnr")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'Garage_2_0Context.User' is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        public JsonResult ValidatePerNum(string Pnr)
        {
            UInt64 i;
            string LuhnStr;

            if (UInt64.TryParse(Pnr, out i))
            {
                if (DateTime.TryParseExact(Pnr.Substring(0, Pnr.Length - 4), "yyyymmdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    LuhnStr = Pnr.Substring(2).Remove(9, 1); // Deletes the first 2 digits and the last digit (yyyymmddxxxx => yymmddxxx)                                                         
                    if (Luhn(LuhnStr) == Pnr[11] - '0')
                    {
                        //dt = DateParse(Pnr);
                        return Json(true);
                    }
                    else
                    {
                        return Json("Invalid personal number format");
                    }
                }
                else
                {
                    return Json("Invalid personal number format");
                }
            }
            else
                return Json("The personal number shall have only digits");
        }

        //private static DateTime DateParse(string Pnr)
        //{
        //    Pnr = Pnr.Remove(8, 4);
        //    int year = int.Parse(Pnr.Substring(0, 4));
        //    int month = int.Parse(Pnr.Substring(4,2));
        //    int day = int.Parse(Pnr.Substring(6, 2));

        //    DateTime date1 = new DateTime(year, month, day);

        //    return date1;

        //}

        private static int Luhn(string value)
        {
            // Luhm algorithm doubles every other number in the value.
            // To get the correct checksum digit we aught to append a 0 on the sequence.
            // If the result becomes a two digit number, subtract 9 from the value.
            // If the total sum is not a 0, the last checksum value should be subtracted from 10.
            // The resulting value is the check value that we use as control number.

            // The value passed is a string, so we aught to get the actual integer value from each char (i.e., subtract '0' which is 48).
            int[] t = value.ToCharArray().Select(d => d - 48).ToArray();
            int sum = 0;
            int temp;
            for (int i = 0; i < t.Length; i++)
            {
                temp = t[i];
                temp *= 2 - (i % 2);
                if (temp > 9)
                {
                    temp -= 9;
                }
                sum += temp;
            }
            sum =  ((int)Math.Ceiling(sum / 10.0)) * 10 - sum;
            return sum;
        }

        [HttpGet]
        public JsonResult ValidateName(string FName, string LName)
        {
            if (String.Equals(FName.ToLower(), LName.ToLower()))
                return Json("FirstName and LastName shall not be the same.");
            else
            {
                return Json(true);
            }

        }
    }
}
