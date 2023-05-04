using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Data;
using Garage_2._0.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using Garage3._0.Core.ViewModels;
using Garage3._0.Core.Entities;

namespace Garage_2._0.Controllers
{
    public class VehicleController : Controller
    {
        private readonly Garage_2_0Context _context;
        public readonly uint _capacity = 9;

        public VehicleController(Garage_2_0Context context)
        {
            _context = context;
        }

        // GET: Vehicle2
        public async Task<IActionResult> Index() 
        {
            //if (_context.Vehicle_old != null)
            //{
            //    var vehicles = await _context.Vehicle_old.ToListAsync();
            //    //ViewData["NrOfParkedVehicles"] = vehicles.Count;

            //    if (vehicles.Count == _capacity) ViewData["NrOfAvailableSlots"] = "The garage is full";
            //    else ViewData["NrOfAvailableSlots"] = _capacity - vehicles.Count;

            //    return View(vehicles);
            //}
            //else return Problem("Entity set 'Garage_2_0Context.Vehicle2'  is null.");

            return View(await _context.Vehicle.Select(v => new IndexViewModel
            {
                Fname = v.User.Fname,
                Lname = v.User.Lname,
                Id = v.Id,
                RegNr = v.RegNr,
                TimeOfArrival = v.TimeOfArrival,
                TypeName = v.VehicleType.TypeName,
                ParkingLot = v.ParkingLot
            }).ToListAsync());
                
            //return _context.Vehicle2 != null ?
            //            View(await _context.Vehicle2.ToListAsync()) :
            //            Problem("Entity set 'Garage_2_0Context.Vehicle2'  is null.");
        }

        // GET: Vehicle2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle2 = await _context.Vehicle.Include(v => v.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle2 == null)
            {
                return NotFound();
            }

            return View(vehicle2);
        }

        // GET: Vehicle2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicle2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegNr,VehicleTypeId,Make,Model,Color,NrOfWheels,UserId")] Vehicle vehicle)
        {
            //if (RegNumExists(vehicle2.RegNr))
            //    ModelState.AddModelError("RegNr", "RegNr is already in the garage.");
            // return Problem("RegNr is already in the garage.");

            var vehicles = await _context.Vehicle.ToListAsync();

            if(vehicles.Count == _capacity)
                return Problem("Garage is Full");

            if (ModelState.IsValid)
            {
                vehicle.RegNr = vehicle.RegNr.ToUpper();
                vehicle.ParkingLot = GetParkingLot();

                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Vehicle with registration number {vehicle.RegNr} has been parked";
                return RedirectToAction(nameof(Index));
                
            }
            return View(vehicle);
        }

        // GET: Vehicle2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicle == null) return NotFound();

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null) return NotFound();

            var viewModel = new Vehicle
            {
                Id = vehicle.Id,
                ParkingLot = vehicle.ParkingLot,
                RegNr = vehicle.RegNr,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Color = vehicle.Color,
                NrOfWheels = vehicle.NrOfWheels,
                TimeOfArrival = vehicle.TimeOfArrival
            };
            
            //var viewModel = new EditVehicleViewModel
            //{
            //    RegNo = vehicle2.RegNr,
            //};

            return View(viewModel);
        }

        // POST: Vehicle2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParkingLot,RegNr,VehicleTypeId,Make,Model,Color,NrOfWheels,UserId")] EditVehicleViewModel vehicleView)
        {
            if (id != vehicleView.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicle = new Vehicle
                    {
                        Id = vehicleView.Id,
                        ParkingLot = vehicleView.ParkingLot,
                        RegNr = vehicleView.RegNr,
                        Make = vehicleView.Make,
                        Model = vehicleView.Model,
                        Color = vehicleView.Color,
                        NrOfWheels = vehicleView.NrOfWheels,
                        TimeOfArrival = vehicleView.TimeOfArrival
                    };
                    
                    _context.Update(vehicle);
                    _context.Entry(vehicle).Property(v => v.TimeOfArrival).IsModified = false;
                    _context.Entry(vehicle).Property(v => v.RegNr).IsModified = false;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicleView.Id)) return NotFound();
                    else throw;
                }
                TempData["Message"] = $"Vehicle has been rebuilt";
                return RedirectToAction(nameof(Index));
            }

            return View(vehicleView);
        }

        // GET: Vehicle2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicle == null) return NotFound();

            var vehicle2 = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);

            if(vehicle2 == null) return NotFound();

            TimeSpan timespan = new TimeSpan();
            timespan = DateTime.Now.Subtract(vehicle2.TimeOfArrival);
            double cost = timespan.TotalMinutes * 0.9;

            int i = timespan.ToString().IndexOf(".");
            ViewBag.TimeParked = timespan.ToString().Remove(i);

            i = cost.ToString().IndexOf(",");
            ViewBag.Cost = cost.ToString().Remove(i + 3);

            return View(vehicle2);
        }

        // POST: Vehicle2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicle == null)
            {
                return Problem("Entity set 'Garage_2_0Context.Vehicle2'  is null.");
            }
            var vehicle2 = await _context.Vehicle.FindAsync(id);
            if (vehicle2 != null)
            {
                _context.Vehicle.Remove(vehicle2);
            }
            
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Vehicle has exited the garage";
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return (_context.Vehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
  
        [HttpGet]
        public JsonResult ValidateRegNum(string regnr)
        {
            var r = new Regex("[A-Z][A-Z][A-Z][1-9][1-9][1-9]");
            if (!r.IsMatch(regnr.ToUpper()))
            {
                return Json("Invalid RegNr format");
            }
            else if ((_context.Vehicle?.Any(r => r.RegNr.ToUpper() == regnr.ToUpper())).GetValueOrDefault())
            {
                return Json("RegNr is already in the garage");
            }

            return Json(true);
        }

        private int GetParkingLot()
        {
            var vehicles = _context.Vehicle.ToList();
            int parkingLot = 0, i = 1;

            foreach (var vehicle in vehicles.OrderBy(p => p.ParkingLot).ToList())
            {
                if (vehicle.ParkingLot > parkingLot + 1) return parkingLot + 1;

                parkingLot = vehicle.ParkingLot;
                i++;
            }

            return i;
        }


        public async Task<IActionResult> Statistics()
        {
            if (_context.Vehicle == null)
            {
                return NotFound();
            }

            var totalCount = await Statistics_1_Async();
            var totalCount2 = await Statistics_2_Async();
            
            if (totalCount == null)
            {
                return NotFound();
            }

            var model = new StatisticsViewModel
            {
                VehicleCount = totalCount,
                VehiclesNoOfWheels = totalCount2
            };
            
            return View(model);
        }

        private async Task<List<VehicleCountDto>> Statistics_1_Async()
        {

            //Linq aggregate
          return await _context.VehicleType.Select(v => new VehicleCountDto
                                                   {
                                                        VehicleType = v.TypeName,
                                                        Total = v.Vehicles.Count(),
                                                    }).ToListAsync();

            //return await _context.Vehicle.GroupBy(v => v.VehicleType)
            //                                     .Select(vt => new VehicleCountDto
            //                                     {
            //                                         VehicleType = vt.Key,
            //                                         Total = vt.Count()
            //                                     }).ToListAsync();

        }

        private async Task<int> Statistics_2_Async()
        {
            return _context.Vehicle.Sum(v => v.NrOfWheels);                                            
        }

        public async Task<IActionResult> Admin()
        {
            return View(await _context.Vehicle.Select(v => new IndexViewModel
            {
                Fname = v.User.Fname,
                Lname = v.User.Lname,
                Id = v.Id,
                RegNr = v.RegNr,
                TimeOfArrival = v.TimeOfArrival,
                TypeName = v.VehicleType.TypeName,
                ParkingLot = v.ParkingLot,
                Make = v.Make,
                Model = v.Model,
                Color = v.Color
            }).ToListAsync());

            //_context.Vehicle.OrderBy(v => v.User.Fname);
            //await _context.SaveChangesAsync();                
        }
        public async Task<IActionResult> Admin2(string searchString)
        {
            var vehicles = from m in _context.Vehicle
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(s => s.RegNr!.Contains(searchString) 
                || s.User.Fname.Contains(searchString) 
                || s.User.Lname.Contains(searchString) 
                || s.VehicleType.TypeName.Contains(searchString));
            }

            var viewModel = vehicles.Select(v => new IndexViewModel
            {
                Fname= v.User.Fname,
                Lname= v.User.Lname,
                ParkingLot= v.ParkingLot,
                TypeName= v.VehicleType.TypeName,
                RegNr= v.RegNr,
                TimeOfArrival= v.TimeOfArrival
            });

            return View(nameof(Admin), await viewModel.ToListAsync());
        }
    }
}
