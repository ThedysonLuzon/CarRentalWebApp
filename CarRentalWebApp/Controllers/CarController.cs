using CarRentalWebApp.Models;
using CarRentalWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalWebApp.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: Car
        public async Task<IActionResult> Index()
        {
            var cars = await _carRepository.GetAllAsync();
            return View(cars);
        }

        // GET: Car/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: Car/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("carid, carrentalid, carmodel, insuranceamount, fueltype, mileage, noofdoors, rentalpriceperday, luggagespace, geartype, freecancelation, caravailability")] Car car)
        {
            if (ModelState.IsValid)
            {
                await _carRepository.AddAsync(car);
                TempData["SuccessMessage"] = "Car created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Car/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("carid, carrentalid, carmodel, insuranceamount, fueltype, mileage, noofdoors, rentalpriceperday, luggagespace, geartype, freecancelation, caravailability")] Car car)
        {
            if (id != car.carid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _carRepository.UpdateAsync(id, car);
                TempData["SuccessMessage"] = "Car edited successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Car/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _carRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = "Car deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
