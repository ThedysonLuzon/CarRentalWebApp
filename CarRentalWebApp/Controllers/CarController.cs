using CarRentalWebApp.Models;
using CarRentalWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalWebApp.Controllers
{
    public class CarController : Controller
    {

        readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // Action for getting all cars
        public async Task<IActionResult> Index()
        {
            return View(await _carRepository.GetAllAsync());
        }

        // Action for getting a car by ID
        public async Task<IActionResult> GetCarById(string id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            return View("Index", new List<Car> { car });
        }

        // Action method for deleting a car
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            await _carRepository.DeleteAsync(id);

            TempData["SuccessMessage"] = "Car has been successfully deleted.";

            return RedirectToAction("Index");
        }

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

        // Implement the POST version of Edit to handle form submission
        [HttpPost]
        public async Task<IActionResult> Edit(string id, Car car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }

            await _carRepository.UpdateAsync(id, car);
            
            TempData["SuccessMessage"] = "Car has been successfully updated.";

            return RedirectToAction("Index");
        }

        // GET action for creating a new car
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST action for creating a new car
        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            try
            {
                await _carRepository.AddAsync(car);
                TempData["SuccessMessage"] = "New car has been successfully added.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

