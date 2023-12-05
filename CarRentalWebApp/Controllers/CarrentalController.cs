using Microsoft.AspNetCore.Mvc;
using CarRentalWebApp.Models;
using CarRentalWebApp.Repositories;
using System.Threading.Tasks;

namespace CarRentalWebApp.Controllers
{
    public class CarRentalController : Controller
    {
        private readonly ICarRentalRepository _carRentalRepository;

        public CarRentalController(ICarRentalRepository carRentalRepository)
        {
            _carRentalRepository = carRentalRepository;
        }

        // GET: CarRental
        public async Task<IActionResult> Index()
        {
            var carRentals = await _carRentalRepository.GetAllAsync();
            return View(carRentals);
        }

        // GET: CarRental/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var carRental = await _carRentalRepository.GetByIdAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }
            return View(carRental);
        }

        // GET: CarRental/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarRental/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Carrentalid,Carrentalcompanyname,Location")] Carrental carRental)
        {
            if (ModelState.IsValid)
            {
                await _carRentalRepository.AddAsync(carRental);
                TempData["SuccessMessage"] = "Car rental added successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(carRental);
        }

        // GET: CarRental/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var carRental = await _carRentalRepository.GetByIdAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }
            return View(carRental);
        }

        // POST: CarRental/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("carrentalid,carrentalcompanyname,location")] Carrental carRental)
        {
            if (id != carRental.carrentalid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _carRentalRepository.UpdateAsync(carRental, id);
                TempData["SuccessMessage"] = "Car rental edited successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(carRental);
        }

        // GET: CarRental/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var carRental = await _carRentalRepository.GetByIdAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }
            return View(carRental);
        }

        // POST: CarRental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _carRentalRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = "Car rental deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
