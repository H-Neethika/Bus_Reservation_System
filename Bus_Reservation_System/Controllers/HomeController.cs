using Bus_Reservation_System.Repositories.Abstract;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Reservation_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusService  _busService;
        public HomeController(IBusService busService)
        {
            _busService = busService;     
        }
        public IActionResult Index(string term1="", string term2 = "", string term3 = "", int currentPage = 1)
        {
            var buses = _busService.List(term1,term2,term3,true,currentPage);
            return View(buses);
        }

        public IActionResult About()
        {
            return View();
        }

        [Authorize]
        public IActionResult BookingPage(int busId)
        {
            var bus = _busService.GetById(busId);
            return View(bus);
        }
    }
}
