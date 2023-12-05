using CarRentalWebApp.Models;
using CarRentalWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalWebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        // GET: Booking
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            return View(bookings);
        }

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bookingid,Carid,Carrentalcompanyid,Customername,Numberofpeople,Luggagespace,InsuranceNeeded,Bookingdate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                await _bookingRepository.AddAsync(booking);
                TempData["SuccessMessage"] = "Booking created successfully.";

                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Booking/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Bookingid,Carid,Carrentalcompanyid,Customername,Numberofpeople,Luggagespace,InsuranceNeeded,Bookingdate")] Booking booking)
        {
            if (id != booking.bookingid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _bookingRepository.UpdateAsync(id, booking);
                TempData["SuccessMessage"] = "Booking edited successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Booking/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookingRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = "Booking deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
