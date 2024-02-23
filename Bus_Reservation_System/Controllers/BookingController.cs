using Bus_Reservation_System.Models.Domain;
using Bus_Reservation_System.Repositories.Abstract;
using Bus_Reservation_System.Repositories.Implementation;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bus_Reservation_System.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IFileService _fileService;
        public BookingController(IBookingService bookingService, IFileService fileService)
        {
            _bookingService = bookingService;
            _fileService = fileService;
        }
        public IActionResult Add()
        {
            var model = new Booking();
          
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Booking model)
        {
           

            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.PaymentSlip = imageName;
            }

            var result = _bookingService.Add(model);
            if (result)
            {
                TempData["msg"] = "Your seat is reserved Successfully.";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }


        public IActionResult BusBookingList()
        {
            var data = this._bookingService.List();
            return View(data);
        }


    }
}
